using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using MetalMastery.Core;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Data;

namespace MetalMastery.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserSet> _userRepository;
        private readonly IRepository<RoleSet> _roleRepository;

        public UserService(IRepository<UserSet> userRepository,
            IRepository<RoleSet> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;

            Mapper.CreateMap<RoleSet, Role>();
            Mapper.CreateMap<User, UserSet>();
        }

        public IPagedList<User> GetAllUsers(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetUsersByRoleId(int customerRoleId)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public void InsertUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            _userRepository.Insert(Mapper.Map<User, UserSet>(user));
            _userRepository.SaveChanges();
        }

        public User GetUserById(Guid userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
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

            return _userRepository.Table
                .Count(u => u.Email == email &&
                    u.Password == password) == 1;
        }

        public Role GetRoleByName(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("roleName");
            }

            var role = _roleRepository.Table
                .FirstOrDefault(r => r.Name == roleName);

            return role == null
                       ? null
                       : Mapper.Map<RoleSet, Role>(role);
        }
    }
}
