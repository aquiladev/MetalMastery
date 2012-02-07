using System.Globalization;

namespace MetalMastery.Web.Infrastructure
{
    public class ViewLocation
    {
        protected readonly string VirtualPathFormatString;

        public ViewLocation(string virtualPathFormatString)
        {
            VirtualPathFormatString = virtualPathFormatString;
        }

        public virtual string Format(string viewName, string controllerName, string areaName, string theme)
        {
            return string.Format(CultureInfo.InvariantCulture, VirtualPathFormatString, viewName, controllerName, theme);
        }
    }
}