using System.Web.Compilation;
using System.Web.Mvc;

namespace MetalMastery.Web.Infrastructure
{
    public abstract class MmBuildManagerViewEngine : MmVirtualPathProviderViewEngine
    {
        #region Methods

        #region Protected Methods

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            return BuildManager.GetObjectFactory(virtualPath, false) != null;
        }

        #endregion Protected Methods

        #endregion Methods
    }
}
