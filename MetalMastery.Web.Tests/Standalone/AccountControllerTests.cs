using System.Web.Mvc;
using AutoMapper;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Areas.Standalone.Controllers;
using MetalMastery.Web.Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace MetalMastery.Web.Tests.Standalone
{
    [TestFixture]
    public class AccountControllerTests
    {
        private MockRepository _mockRepository;
        private IAuthenticationService _authenticationService;
        private IUserService _userService;
        private IEmailSender _emailSender;

        private AccountController _userController;

        private const string EmailTest = "test@ads.we";
        private const string PwdTest = "pwd123!";

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _authenticationService = _mockRepository.DynamicMock<IAuthenticationService>();
            _userService = _mockRepository.DynamicMock<IUserService>();
            _emailSender = _mockRepository.DynamicMock<IEmailSender>();

            _userController = new AccountController(
                _authenticationService,
                _userService,
                _emailSender);

            Mapper.CreateMap<SignUpModel, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdmin, opt => opt.Ignore())
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ForMember(dest => dest.Articles, opt => opt.Ignore());
        }

        [Test]
        public void SignIn_IncorectEmailOrPassword_ReturnError()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.ValidateUser(string.Empty, null))
                    .IgnoreArguments().Return(false);
            }

            var result = _userController.SignIn(new SignInModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.UserNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }


        [Test]
        public void SignIn_FoundedUser_RedirectToHome()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.ValidateUser(string.Empty, null))
                    .IgnoreArguments().Return(true);
                _userService.Stub(x => x.GetUserByEmail(string.Empty))
                    .IgnoreArguments().Return(new User { Email = EmailTest });
            }

            var result = (RedirectToRouteResult)_userController.SignIn(new SignInModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["controller"], "Home");
        }


        [Test]
        public void SignIn_ModelStateError_GoToView()
        {
            _userController.ModelState.AddModelError("Email", "err");

            var result = _userController.SignIn(new SignInModel { Email = EmailTest, Password = PwdTest });

            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void SignUp_ModelStateError_GoToView()
        {
            _userController.ModelState.AddModelError("Email", "err");

            var result = _userController.SignUp(new SignUpModel { Email = EmailTest, Password = PwdTest });

            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void SignUp_DublicateUser_ReturnError()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetUserByEmail(string.Empty))
                    .IgnoreArguments().Return(new User { Email = EmailTest });
            }

            var result = _userController.SignUp(new SignUpModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.DublicateUser);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void SignUp_CorrectInsert_RedirectToHome()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.Insert(null))
                    .IgnoreArguments();
            }

            var result = (RedirectToRouteResult)_userController.SignUp(new SignUpModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["controller"], "Home");
        }
    }
}
