using System.Web.Mvc;
using MetalMastery.Web.Framework.Controller;

namespace MetalMastery.Web.Areas.Admin.Controllers
{
    [AdminAuthorize]
    [HandleErrorWithElmah]
    public class BaseAdminController : Controller { }
}
