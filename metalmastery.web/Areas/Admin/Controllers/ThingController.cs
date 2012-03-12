using System;
using System.Linq;
using System.Web.Mvc;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Areas.Admin.Models;

namespace MetalMastery.Web.Areas.Admin.Controllers
{   
    public class ThingController : Controller
    {
        private readonly IThingService _thingService;
        private readonly ITagService _tagService;
        private readonly IMaterialService _materialService;
        private readonly IFormatService _formatService;
        private readonly IStateService _stateService;
        private readonly IUserService _userService;

        public ThingController(
            IThingService thingService,
            ITagService tagService,
            IMaterialService materialService,
            IFormatService formatService,
            IStateService stateService,
            IUserService userService)
        {
            _thingService = thingService;
            _tagService = tagService;
            _materialService = materialService;
            _formatService = formatService;
            _stateService = stateService;
            _userService = userService;
        }

        public ViewResult Index(int pageIndex = 0, int pageSize = 10)
        {
            return View(_thingService.GetAll(pageIndex, pageSize)
                .Select(x => x.ToModel())
                .ToList());
        }

        public ViewResult Details(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            return View(_thingService.GetEntityById(id).ToModel());
        }

        public ActionResult Create()
        {
            InitViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]ThingModel thing)
        {
            if (!ModelState.IsValid)
            {
                InitViewBag();
                return View(thing);
            }

            var state = _stateService.GetThingByName(States.Idea.ToString());

            if (state == null)
            {
                ViewBag.Error = MmResources.StateNotFound;
                return View(thing);
            }

            thing.StateId = state.Id;

            _thingService.Insert(thing.ToEntity());

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                return RedirectToAction("Index");
            }

            var thing = _thingService.GetEntityById(id).ToModel();

            if (thing == null)
            {
                return RedirectToAction("Index");
            }

            InitViewBag();
            return View(thing);
        }


        [HttpPost]
        public ActionResult Edit(ThingModel thing)
        {
            if (!ModelState.IsValid)
            {
                InitViewBag();
                return View(_thingService.GetEntityById(thing.Id).ToModel());
            }

            _thingService.Update(thing.ToEntity());

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var thing = _thingService.GetEntityById(id);

            if (thing == null)
            {
                ViewBag.Error = MmResources.ThingNotFound;
                return View();
            }

            return View(thing.ToModel());
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var thing = _thingService.GetEntityById(id);

            if (thing == null)
            {
                ViewBag.Error = MmResources.ThingNotFound;
                return View();
            }

            _thingService.Delete(thing);

            return RedirectToAction("Index");
        }

        private void InitViewBag()
        {
            ViewBag.Tags = _tagService.GetAll();
            ViewBag.Materials = _materialService.GetAll();
            ViewBag.Formats = _formatService.GetAll();
        }
    }
}