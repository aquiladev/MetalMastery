using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace MetalMastery.Services.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private MockRepository _mockRepository;
        private IRepository<User> _userRepository;

        private IUserService _userService;

        private string _pwd = "pwd";

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _userRepository = _mockRepository.DynamicMock<IRepository<User>>();

            _userService = new UserService(_userRepository);
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("", null)]
        [TestCase(null, "")]
        [TestCase("", "test")]
        [TestCase(null, "test")]
        [TestCase("email", null)]
        [TestCase("email", "")]
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

            var result = _userService.ValidateUser("test@te.te", _pwd);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateUser_NotExistUser()
        {
            var users = InitUserSets();

            using (_mockRepository.Record())
            {
                _userRepository.Table.Stub(x => x).Return(users.AsQueryable());
            }

            var result = _userService.ValidateUser("test@sa.sa", _pwd);

            Assert.IsFalse(result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertUser_UserIsNull_Exception()
        {
            _userService.InsertUser(null);
        }

        [Test]
        public void GetAllUsers_CorrectCount()
        {
            using (_mockRepository.Record())
            {
                _userRepository.Stub(x => x.Table)
                    .Return((new List<User> { new User() })
                                .AsQueryable());
            }

            var result = _userService.GetAllUsers(0, 1);

            Assert.AreEqual(result.Count(), 1);
        }

        [Test]
        public void GetAllUsers_WithPaging_CorrectCount()
        {
            var users = new List<User>();
            for (int i = 0; i < 6; i++)
            {
                users.Add(new User());
            }

            using (_mockRepository.Record())
            {
                _userRepository.Stub(x => x.Table)
                    .Return(users.AsQueryable());
            }

            var result = _userService.GetAllUsers(1, 4);

            Assert.AreEqual(result.Count(), 2);
        }

        [Test]
        public void GetUserById_NotFound_ReturnNull()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _userRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _userService.GetUserById(id);

            Assert.IsNull(result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUserById_IdEmpty_Exception()
        {
            _userService.GetUserById(Guid.Empty);
        }

        [Test]
        public void GetUserById_Founded()
        {
            var id = Guid.NewGuid();
            var user = new User { Id = id };

            using (_mockRepository.Record())
            {
                _userRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(new List<User>
                                {
                                    user
                                });
            }

            var result = _userService.GetUserById(id);

            Assert.IsNotNull(result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUserByEmail_EmailIsEmpty_Exception()
        {
            _userService.GetUserByEmail(string.Empty);
        }

        [Test]
        public void GetUserByEmail_NotFound_ReturnNull()
        {
            using (_mockRepository.Record())
            {
                _userRepository.Stub(x => x.Find(y => y.Email == string.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _userService.GetUserByEmail("email");

            Assert.IsNull(result);
        }

        [Test]
        public void GetUserByEmail_Founded()
        {
            var user = new User { Id = Guid.NewGuid() };

            using (_mockRepository.Record())
            {
                _userRepository.Stub(x => x.Find(y => y.Email == string.Empty))
                    .IgnoreArguments()
                    .Return(new List<User>
                                {
                                    user
                                });
            }

            var result = _userService.GetUserByEmail("email");

            Assert.IsNotNull(result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteUser_UserIsNull_Exception()
        {
            _userService.DeleteUser(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateUser_UserIsNull_Exception()
        {
            _userService.UpdateUser(null);
        }

        #region
        private IEnumerable<User> InitUserSets()
        {
            var hash = SHA1.Create();
            var pwd = hash.ComputeHash(Encoding.ASCII.GetBytes(_pwd));

            return new List<User>
                            {
                                new User{ Email = "test@te.te", Password = pwd},
                                new User{ Email = "seta@sa.sa", Password = pwd}
                            };
        }
        #endregion
    }
}
