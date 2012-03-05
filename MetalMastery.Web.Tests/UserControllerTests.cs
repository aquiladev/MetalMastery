using System;
using System.Reflection;
using System.Web.Mvc;
using MetalMastery.Core.Domain;
using MetalMastery.Core.Mvc;
using MetalMastery.Services;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Controllers;
using MetalMastery.Web.Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace MetalMastery.Web.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        private MockRepository _mockRepository;
        private IAuthenticationService _authenticationService;
        private IUserService _userService;
        private IEmailSender _emailSender;

        private UserController _userController;

        private const string EmailTest = "test@ads.we";
        private const string PwdTest = "pwd123!";

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _authenticationService = _mockRepository.DynamicMock<IAuthenticationService>();
            _userService = _mockRepository.DynamicMock<IUserService>();
            _emailSender = _mockRepository.DynamicMock<IEmailSender>();

            _userController = new UserController(
                _authenticationService,
                _userService,
                _emailSender);
        }

        [Test]
        public void SignIn_IncorectEmailOrPassword_ReturnError()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.ValidateUser(string.Empty, null))
                    .IgnoreArguments().Return(false);
            }

            var result = _userController.SignIn(new LogOnModel { Email = EmailTest, Password = PwdTest });

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

            var result = _userController.SignIn(new LogOnModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(((MmJsonResult)result).Success, true);
        }

        [Test]
        public void SignUp_CorrectInsert()
        {
            var stubRole = new Role { Id = Guid.NewGuid() };

            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetRoleByName(string.Empty))
                    .IgnoreArguments()
                    .Return(stubRole);

                _userService.Stub(x => x.InsertUser(null))
                    .IgnoreArguments();
            }

            var result = _userController.SignUp(new RegistrateModel { Email = EmailTest, Password = PwdTest });

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

            var result = _userController.SignUp(new RegistrateModel{ Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(((MmJsonResult)result).Success, false);
            Assert.AreEqual(((MmJsonResult)result).Errors.Count, 1);
        }

        [Test]
        public void LogIn_IncorectEmailOrPassword_ReturnError()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.ValidateUser(string.Empty, null))
                    .IgnoreArguments().Return(false);
            }

            var result = _userController.LogIn(new LogOnModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.UserNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void LogIn_FoundedUser_RedirectToHome()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.ValidateUser(string.Empty, null))
                    .IgnoreArguments().Return(true);
                _userService.Stub(x => x.GetUserByEmail(string.Empty))
                    .IgnoreArguments().Return(new User { Email = EmailTest });
            }

            var result = (RedirectToRouteResult)_userController.LogIn(new LogOnModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["controller"], "Home");
        }

        [Test]
        public void LogIn_ModelStateError_GoToView()
        {
            _userController.ModelState.AddModelError("Email", "err");

            var result = _userController.LogIn(new LogOnModel { Email = EmailTest, Password = PwdTest });

            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void LogOn_ModelStateError_GoToView()
        {
            _userController.ModelState.AddModelError("Email", "err");

            var result = _userController.LogOn(new RegistrateModel { Email = EmailTest, Password = PwdTest });

            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void LogOn_DublicateUser_ReturnError()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetUserByEmail(string.Empty))
                    .IgnoreArguments().Return(new User { Email = EmailTest });
            }

            var result = _userController.LogOn(new RegistrateModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.DublicateUser);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void LogOn_CorrectInsert_RedirectToHome()
        {
            var stubRole = new Role { Id = Guid.NewGuid() };

            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetRoleByName(string.Empty))
                    .IgnoreArguments()
                    .Return(stubRole);

                _userService.Stub(x => x.InsertUser(null))
                    .IgnoreArguments();
            }

            var result = (RedirectToRouteResult)_userController.LogOn(new RegistrateModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["controller"], "Home");
        }
    }
}
