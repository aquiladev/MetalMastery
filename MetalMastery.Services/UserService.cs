using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MetalMastery.Core;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IPagedList<User> GetAllUsers(int pageIndex, int pageSize)
        {
            return new PagedList<User>(_userRepository
                                           .Table
                                           .ToList(),
                                       pageIndex,
                                       pageSize);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            _userRepository.Delete(user);
            _userRepository.SaveChanges();
        }

        public void InsertUser(User user, Roles roleType = Roles.Customer)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            var hash = SHA1.Create();

            _userRepository.Insert(new User
                                       {
                                           Id = Guid.NewGuid(),
                                           Email = user.Email,
                                           Password = hash.ComputeHash(user.Password),
                                           IsAdmin = roleType.Equals(Roles.Administrator)
                                       });
            _userRepository.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            var users = _userRepository.Find(x => x.Id == user.Id);
            var userRep = users == null
                ? null
                : users.FirstOrDefault();

            if (userRep != null)
            {
                userRep.IsAdmin = user.IsAdmin;

                _userRepository.SaveChanges();
            }
        }

        public User GetUserById(Guid userId)
        {
            if (userId.Equals(default(Guid)))
            {
                throw new ArgumentNullException("userId");
            }

            var user = _userRepository.Find(u => u.Id == userId);
            return user == null
                ? null
                : user.FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }

            var user = _userRepository.Find(u => u.Email == email);
            return user == null
                ? null
                : user.FirstOrDefault();
        }

        public bool ValidateUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }

            var hash = SHA1.Create();
            var pwd = hash.ComputeHash(Encoding.ASCII.GetBytes(password));

            var user = _userRepository.Table
                .ToList()
                .SingleOrDefault(u => u.Email == email &&
                                      u.Password.SequenceEqual(pwd));
            return user != null;
        }
    }
}
