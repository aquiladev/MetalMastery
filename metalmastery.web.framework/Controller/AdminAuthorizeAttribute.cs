using System.Web;
using System.Web.Mvc;

namespace MetalMastery.Web.Framework.Controller
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current == null)
                return false;

            var user = HttpContext.Current.User;

            if (user.Identity.IsAuthenticated &&
                user.IsInRole(Core.Domain.Roles.Administrator.ToString()))
                return true;

            return false;
        }
    }
}
