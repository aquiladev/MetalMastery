using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using MetalMastery.Core;
using MetalMastery.Core.Domain;
using MetalMastery.Services;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Areas.Admin.Controllers;
using MetalMastery.Web.Areas.Admin.Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace MetalMastery.Web.Tests.Admin
{
    [TestFixture]
    public class AdminUserControllerTests
    {
        private IUserService _userService;
        private MockRepository _mockRepository;
        private UserController _userController;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _userService = _mockRepository.DynamicMock<IUserService>();

            _userController = new UserController(_userService);
            Mapper.CreateMap<User, UserModel>();
            Mapper.CreateMap<UserModel, User>();
        }

        [Test]
        public void Index_ReturnUsers_CorrectCount()
        {
            IPagedList<User> userList = new PagedList<User>(
                new List<User>
                    {
                        new User(),
                        new User()
                    },
                0, 2);

            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetAllUsers(0, 0)).IgnoreArguments().Return(userList);
            }

            var result = _userController.Index();

            Assert.AreEqual(((List<UserModel>)result.Model).Count, 2);
        }

        [Test]
        public void Edit_IdIsEmpty_Error()
        {
            var result = _userController.Edit(Guid.Empty);

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.IdEmptyError);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Edit_UserNotFound_Error()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetUserById(id)).Return(null);
            }

            var result = _userController.Edit(id);

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.UserNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Edit_GetAllRoles_CorrectCount()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetUserById(id)).Return(null);
                _userService.Stub(x => x.GetAllRoles()).Return(new List<Role> {new Role {Name = "role1"}});
            }

            var result = _userController.Edit(id);
            var roles = ((ViewResultBase) result).ViewBag.PossibleRoles;

            Assert.AreEqual(((List<Role>)roles).Count, 1);
        }

        [Test]
        public void Edit_FoundedUser_CorrectView()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetUserById(id)).Return(new User());
            }

            var result = _userController.Edit(id);

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void EditPost_ModelIncorrect()
        {
            _userController.ModelState.AddModelError("Email", "err");

            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetAllRoles())
                    .Return(new List<Role> { new Role { Name = "role1" } });
                _userService.Stub(x => x.GetUserById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new User());
            }

            var result = _userController.Edit(new UserModel());

            Assert.IsNotNull(((ViewResultBase)result).ViewBag.PossibleRoles);
            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void EditPost_ModelIncorrect_RolesGetCorrectCount()
        {
            var id = Guid.NewGuid();

            _userController.ModelState.AddModelError("Email", "err");

            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetAllRoles()).Return(new List<Role> { new Role { Name = "role1" } });
            }

            var result = _userController.Edit(new UserModel());
            var roles = ((ViewResultBase)result).ViewBag.PossibleRoles;

            Assert.AreEqual(((List<Role>)roles).Count, 1);
        }

        [Test]
        public void EditPost_CorrectEdit_Redirect()
        {
            var result = (RedirectToRouteResult)_userController.Edit(new UserModel());
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Delete_GetUser_ModelNotNull()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetUserById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new User());
            }

            var result = _userController.Delete(Guid.NewGuid());
            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_IdIsEmpty_Exception()
        {
            _userController.Delete(Guid.Empty);
        }

        [Test]
        public void Delete_UserNotFound_Error()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetUserById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _userController.Delete(Guid.NewGuid());

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.UserNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteConfirmed_IdIsEmpty_Exception()
        {
            _userController.DeleteConfirmed(Guid.Empty);
        }

        [Test]
        public void DeleteConfirmed_UserNotFound_Error()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetUserById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _userController.DeleteConfirmed(Guid.NewGuid());

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.UserNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void DeleteConfirmed_CorrectDelete_Redirect()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetUserById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new User());
            }

            var result = (RedirectToRouteResult)_userController.DeleteConfirmed(Guid.NewGuid());

            Assert.AreEqual(result.RouteValues["action"], "Index");
        }
    }
}
