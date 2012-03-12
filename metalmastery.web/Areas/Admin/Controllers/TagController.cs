using System;
using System.Linq;
using System.Web.Mvc;
using MetalMastery.Services.Interfaces;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Areas.Admin.Models;

namespace MetalMastery.Web.Areas.Admin.Controllers
{
    public class TagController : BaseAdminController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public ViewResult Index()
        {
            return View(_tagService.GetAll(0, 10)
                            .Select(x => x.ToModel())
                            .ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]TagModel tag)
        {
            if (!ModelState.IsValid)
            {
                return View(tag);
            }

            _tagService.Insert(tag.ToEntity());

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                ViewBag.Error = MmResources.IdEmptyError;
                return View();
            }

            var tag = _tagService.GetEntityById(id).ToModel();

            if (tag == null)
            {
                ViewBag.Error = MmResources.TagNotFound;
                return View();
            }

            return View(tag);
        }

        [HttpPost]
        public ActionResult Edit(TagModel tag)
        {
            if (!ModelState.IsValid)
            {
                return View(_tagService.GetEntityById(tag.Id).ToModel());
            }

            _tagService.Update(tag.ToEntity());

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var tag = _tagService.GetEntityById(id);

            if (tag == null)
            {
                ViewBag.Error = MmResources.TagNotFound;
                return View();
            }

            return View(tag.ToModel());
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var tag = _tagService.GetEntityById(id);

            if (tag == null)
            {
                ViewBag.Error = MmResources.TagNotFound;
                return View();
            }

            _tagService.Delete(tag);

            return RedirectToAction("Index");
        }
    }
}