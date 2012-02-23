using System.Web.Mvc;

namespace MetalMastery.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
