using System;
using System.Linq;
using System.Web.Mvc;
using MetalMastery.Services;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Areas.Admin.Models;

namespace MetalMastery.Web.Areas.Admin.Controllers
{
    public class FormatController : BaseAdminController
    {
        private readonly IFormatService _formatService;

        public FormatController(IFormatService formatService)
        {
            _formatService = formatService;
        }

        public ViewResult Index()
        {
            return View(_formatService.GetAllFormats(0, 10)
                            .Select(x => x.ToModel())
                            .ToList());
        }

        public ActionResult Create()
        {
            return View();
        } 
        
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]FormatModel format)
        {
            if (!ModelState.IsValid)
            {
                return View(format);
            }

            _formatService.InsertFormat(format.ToEntity());

            return RedirectToAction("Index");
        }
 
        public ActionResult Edit(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                ViewBag.Error = MmResources.IdEmptyError;
                return View();
            }

            var format = _formatService.GetFormatById(id).ToModel();

            if (format == null)
            {
                ViewBag.Error = MmResources.FormatNotFound;
                return View();
            }

            return View(format);
        }

        [HttpPost]
        public ActionResult Edit(FormatModel format)
        {
            if (!ModelState.IsValid)
            {
                return View(_formatService.GetFormatById(format.Id).ToModel());
            }

            _formatService.UpdateFormat(format.ToEntity());

            return RedirectToAction("Index");
        }
 
        public ActionResult Delete(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var format = _formatService.GetFormatById(id);

            if (format == null)
            {
                ViewBag.Error = MmResources.FormatNotFound;
                return View();
            }

            return View(format.ToModel());
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var format = _formatService.GetFormatById(id);

            if (format == null)
            {
                ViewBag.Error = MmResources.FormatNotFound;
                return View();
            }

            _formatService.DeleteFormat(format);

            return RedirectToAction("Index");
        }
    }
}