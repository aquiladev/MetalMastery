using System;
using System.Linq;
using System.Web.Mvc;
using MetalMastery.Core.Mvc;
using MetalMastery.Services.Interfaces;
using MetalMastery.Web.Framework.Filters;

namespace MetalMastery.Web.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class ThingController : Controller
    {
        private readonly IThingService _thingService;

        public ThingController(IThingService thingService)
        {
            _thingService = thingService;
        }

        [CheckModelFilter]
        public JsonResult GetThings(int pageIndex = 0, int pageSize = 10)
        {
            return new MmJsonResult(_thingService.GetPublishedCompletedThings(pageIndex, pageSize)
                                        .Select(x => x.ToModel())
                                        .ToList());
        }

        [CheckModelFilter]
        public JsonResult Details(Guid id)
        {
            return new MmJsonResult(_thingService.GetEntityById(id).ToModel());
        }
    }
}
