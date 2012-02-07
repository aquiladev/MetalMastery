using System.Globalization;

namespace MetalMastery.Web.Infrastructure
{
    public class AreaAwareViewLocation : ViewLocation
    {
        public AreaAwareViewLocation(string virtualPathFormatString)
            : base(virtualPathFormatString)
        {
        }

        public override string Format(string viewName, string controllerName, string areaName, string theme)
        {
            return string.Format(CultureInfo.InvariantCulture, VirtualPathFormatString, viewName, controllerName, areaName, theme);
        }
    }
}