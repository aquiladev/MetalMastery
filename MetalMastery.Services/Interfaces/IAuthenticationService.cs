using MetalMastery.Core.Domain;

namespace MetalMastery.Services.Interfaces
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