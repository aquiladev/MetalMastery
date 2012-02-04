using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    /// <summary>
    /// Authentication service interface
    /// </summary>
    public interface IAuthenticationService 
    {
        void SignIn(User user, bool createPersistentCookie);
        void SignOut();
    }
}