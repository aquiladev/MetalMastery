using System;
using System.Linq;
using System.Web.Mvc;
using MetalMastery.Admin.App_LocalResources;
using MetalMastery.Admin.Models;
using MetalMastery.Services;

namespace MetalMastery.Admin.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public ViewResult Index()
        {
            return View(_tagService.GetAllTags(0, 10)
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

            _tagService.InsertTag(tag.ToEntity());

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                ViewBag.Error = MmAdminResources.IdEmptyError;
                return View();
            }

            var tag = _tagService.GetTagById(id).ToModel();

            if (tag == null)
            {
                ViewBag.Error = MmAdminResources.TagDidntFound;
                return View();
            }

            return View(tag);
        }

        [HttpPost]
        public ActionResult Edit(TagModel tag)
        {
            if (!ModelState.IsValid)
            {
                return View(_tagService.GetTagById(tag.Id).ToModel());
            }

            _tagService.UpdateTag(tag.ToEntity());

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var tag = _tagService.GetTagById(id);

            if (tag == null)
            {
                ViewBag.Error = MmAdminResources.TagDidntFound;
                return View();
            }

            return View(tag.ToModel());
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var tag = _tagService.GetTagById(id);

            if (tag == null)
            {
                ViewBag.Error = MmAdminResources.TagDidntFound;
                return View();
            }

            _tagService.DeleteTag(tag);

            return RedirectToAction("Index");
        }
    }
}