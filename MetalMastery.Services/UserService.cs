using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using MetalMastery.Core;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;

        public UserService(IRepository<User> userRepository,
            IRepository<Role> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
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
            var role = GetRoleByName(roleType.ToString());

            if (role == null)
                throw new InvalidOperationException();

            _userRepository.Insert(new User
                                       {
                                           Id = Guid.NewGuid(),
                                           Email = user.Email,
                                           Password = hash.ComputeHash(user.Password),
                                           RoleId = role.Id
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
                userRep.RoleId = user.RoleId;

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

        public bool ValidateUser(string email, byte[] password)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            var hash = SHA1.Create();
            var pwd = hash.ComputeHash(password);
            return _userRepository.Table
                .Count(u => u.Email == email &&
                    u.Password == pwd) == 1;
        }

        public Role GetRoleByName(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("roleName");
            }

            var role = _roleRepository.Find(r => r.Name == roleName);

            return role == null
                       ? null
                       : role.FirstOrDefault();
        }

        public IList<Role> GetAllRoles()
        {
            return _roleRepository
                .Table
                .ToList();
        }
    }
}
