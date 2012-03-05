using System;
using System.Collections.Generic;
using MetalMastery.Core;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    /// <summary>
    /// User service interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get all with paging
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>User collection</returns>
        IPagedList<User> GetAllUsers(int pageIndex, int pageSize);

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="user">User</param>
        void DeleteUser(User user);

        /// <summary>
        /// Insert a user
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="role">Role</param>
        void InsertUser(User user, Roles role = Roles.Customer);

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user">User</param>
        void UpdateUser(User user);

        /// <summary>
        /// Get a user by idetity
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns>User</returns>
        User GetUserById(Guid userId);

        /// <summary>
        /// Gets a user by email
        /// </summary>
        /// <param name="email">email users</param>
        /// <returns>User</returns>
        User GetUserByEmail(string email);

        /// <summary>
        /// Validate user
        /// </summary>
        /// <param name="usernameOrEmail">Username or email</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        bool ValidateUser(string usernameOrEmail, string password);

        /// <summary>
        /// Get role by role name
        /// </summary>
        /// <param name="roleName">Role name</param>
        /// <returns>The role</returns>
        Role GetRoleByName(string roleName);

        /// <summary>
        /// Get all active roles
        /// </summary>
        /// <returns>Roles</returns>
        IList<Role> GetAllRoles();
    }
}