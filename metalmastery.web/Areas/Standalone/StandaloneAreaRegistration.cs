using System.Web.Mvc;

namespace MetalMastery.Web.Areas.Standalone
{
    public class StandaloneAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Standalone";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Standalone_default",
                "s/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
