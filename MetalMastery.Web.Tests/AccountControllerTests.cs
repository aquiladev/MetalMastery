using System.Web.Mvc;
using AutoMapper;
using MetalMastery.Core.Domain;
using MetalMastery.Core.Mvc;
using MetalMastery.Services.Interfaces;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Controllers;
using MetalMastery.Web.Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace MetalMastery.Web.Tests
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
                .ForMember(dest => dest.Password, opt=>opt.Ignore())
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

            Assert.AreEqual(((MmJsonResult)result).Success, false);
            Assert.AreEqual(((MmJsonResult)result).Errors.Count, 1);
        }

        [Test]
        public void SignIn_CorrectAll()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.ValidateUser(string.Empty, null))
                    .IgnoreArguments().Return(true);
                _userService.Stub(x => x.GetUserByEmail(string.Empty))
                    .IgnoreArguments().Return(new User { Email = EmailTest });
            }

            var result = _userController.SignIn(new SignInModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(((MmJsonResult)result).Success, true);
        }

        [Test]
        public void SignUp_CorrectInsert()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.Insert(null))
                    .IgnoreArguments();
            }

            var result = _userController.SignUp(new SignUpModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(((MmJsonResult)result).Success, true);
        }

        [Test]
        public void SignUp_DublicateEmail_ReturnError()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetUserByEmail(string.Empty))
                    .IgnoreArguments().Return(new User { Email = EmailTest });
            }

            var result = _userController.SignUp(new SignUpModel{ Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(((MmJsonResult)result).Success, false);
            Assert.AreEqual(((MmJsonResult)result).Errors.Count, 1);
        }
    }
}
