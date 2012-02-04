using System;
using System.Web;
using System.Web.Security;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public class FormAuthenticationService : IAuthenticationService
    {
        private readonly HttpContextBase _httpContext;
        private readonly TimeSpan _expirationTimeSpan;

        /// <summary>
        /// Ctor
        /// </summary>
        public FormAuthenticationService(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
            _expirationTimeSpan = FormsAuthentication.Timeout;
        }

        public void SignIn(User user, bool createPersistentCookie)
        {
            var now = DateTime.UtcNow.ToLocalTime();

            var ticket = new FormsAuthenticationTicket(1,
                user.Email,
                now, 
                now.Add(_expirationTimeSpan),
                createPersistentCookie,
                user.Email,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.Expires = now.Add(_expirationTimeSpan);
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            _httpContext.Response.Cookies.Add(cookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
