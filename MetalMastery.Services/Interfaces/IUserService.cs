using MetalMastery.Core.Domain;

namespace MetalMastery.Services.Interfaces
{
    /// <summary>
    /// User service interface
    /// </summary>
    public interface IUserService : IBaseEntityService<User>
    {
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
    }
}