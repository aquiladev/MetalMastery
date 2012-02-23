using System.Linq;
using System.Web.Mvc;
using MetalMastery.Core.Mvc;

namespace MetalMastery.Web.Framework.Filters
{
    public class CheckModelFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var modelState = filterContext.Controller.ViewData.ModelState;
            if (!modelState.IsValid)
            {
                filterContext.Result = new MmJsonResult(
                    data: null,
                    success: false,
                    errors: modelState.Keys
                        .SelectMany(key => modelState[key].Errors)
                        .Select(err => err.ErrorMessage).ToList());
            }
        }
    }
}