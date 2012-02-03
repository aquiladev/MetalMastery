using System;
using System.Reflection;
using MetalMastery.Core.Domain;
using MetalMastery.Core.Mvc;
using MetalMastery.Services;
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
        public void LogIn_IncorectEmailOrPassword_ReturnError()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.ValidateUser(string.Empty, string.Empty))
                    .IgnoreArguments().Return(false);
            }

            var result = _userController.LogIn(new UserModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(((MmJsonResult)result).Success, false);
            Assert.AreEqual(((MmJsonResult)result).Errors.Count, 1);
        }

        [Test]
        public void LogIn_CorrectAll()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.ValidateUser(string.Empty, string.Empty))
                    .IgnoreArguments().Return(true);
            }

            var result = _userController.LogIn(new UserModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(((MmJsonResult)result).Success, true);
        }

        [Test]
        public void LogOn_RoleNotFound_ReturnError()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetRoleByName(string.Empty))
                    .IgnoreArguments()
                    .Return(null);

                _userService.Stub(x => x.InsertUser(null))
                    .IgnoreArguments();
            }

            var result = _userController.LogOn(new RegistrateModel {Email = EmailTest, Password = PwdTest});

            Assert.AreEqual(((MmJsonResult)result).Success, false);
            Assert.AreEqual(((MmJsonResult)result).Errors.Count, 1);
        }

        [Test]
        public void LogOn_CorrectInsert()
        {
            var stubRole = new Role();
            stubRole.GetType()
                .InvokeMember(
                    "Id",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance,
                    null,
                    stubRole,
                    new object[] {Guid.NewGuid()});

            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetRoleByName(string.Empty))
                    .IgnoreArguments()
                    .Return(stubRole);
                
                _userService.Stub(x => x.InsertUser(null))
                    .IgnoreArguments();
            }

            var result = _userController.LogOn(new RegistrateModel { Email = EmailTest, Password = PwdTest });

            Assert.AreEqual(((MmJsonResult)result).Success, true);
        }
    }
}
