using System;
using System.Collections.Generic;
using System.Linq;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Data;
using NUnit.Framework;
using Rhino.Mocks;
using AutoMapper;

namespace MetalMastery.Services.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private MockRepository _mockRepository;
        private IRepository<UserSet> _userRepository;
        private IRepository<RoleSet> _roleRepository;

        private IUserService _userService;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _userRepository = _mockRepository.DynamicMock<IRepository<UserSet>>();
            _roleRepository = _mockRepository.DynamicMock<IRepository<RoleSet>>();

            _userService = new UserService(_userRepository, _roleRepository);
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(null, "")]
        [TestCase("", null)]
        [TestCase("", "pwd")]
        [TestCase("email", "")]
        [TestCase(null, "pwd")]
        [TestCase("email", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateUser_IncorrectParams_Erxception(string email, string pwd)
        {
            _userService.ValidateUser(email, pwd);
        }

        [Test]
        public void ValidateUser_ExistUser()
        {
            var users = InitUserSets();

            using (_mockRepository.Record())
            {
                _userRepository.Table.Stub(x => x).Return(users.AsQueryable());
            }

            var result = _userService.ValidateUser("test@te.te", "123qw!");

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateUser_DontExistUser()
        {
            var users = InitUserSets();

            using (_mockRepository.Record())
            {
                _userRepository.Table.Stub(x => x).Return(users.AsQueryable());
            }

            var result = _userService.ValidateUser("test@sa.sa", "123qw!");

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetRoleByName_EmptyRoleName_Exception(string roleName)
        {
            _userService.GetRoleByName(roleName);
        }

        [Test]
        public void GetRoleByName_ExistRole()
        {
            var role = InitRoleSets();

            using (_mockRepository.Record())
            {
                _roleRepository.Table.Stub(x => x).Return(role.AsQueryable());
            }

            var result = _userService.GetRoleByName("fest");

            Assert.IsTrue(result != null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertUser_UserIsNull_Exception()
        {
            _userService.InsertUser(null);
        }

        [Test]
        [ExpectedException(typeof(AutoMapperMappingException))]
        public void InsertUser_UserNotValid_Exception()
        {
            _userService.InsertUser(new User());
        }

        private IEnumerable<UserSet> InitUserSets()
        {
            return new List<UserSet>
                            {
                                new UserSet{ Email = "test@te.te", Password = "123qw!"},
                                new UserSet{ Email = "seta@sa.sa", Password = "1231q!"}
                            };
        }

        private IEnumerable<RoleSet> InitRoleSets()
        {
            return new List<RoleSet>
                            {
                                new RoleSet{ Name = "tset"},
                                new RoleSet{ Name = "fest"}
                            };
        }
    }
}
