using System;
using System.Linq;
using System.Web.Mvc;
using MetalMastery.Services.Interfaces;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Areas.Admin.Models;

namespace MetalMastery.Web.Areas.Admin.Controllers
{
    public class MaterialController : BaseAdminController
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        public ViewResult Index()
        {
            return View(_materialService.GetAll(0, 10)
                            .Select(x => x.ToModel())
                            .ToList());
        }

        public ActionResult Create()
        {
            return View();
        } 
        
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]MaterialModel material)
        {
            if (!ModelState.IsValid)
            {
                return View(material);
            }

            _materialService.Insert(material.ToEntity());

            return RedirectToAction("Index");
        }
 
        public ActionResult Edit(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                ViewBag.Error = MmResources.IdEmptyError;
                return View();
            }

            var material = _materialService.GetEntityById(id).ToModel();

            if (material == null)
            {
                ViewBag.Error = MmResources.MaterialNotFound;
                return View();
            }

            return View(material);
        }

        [HttpPost]
        public ActionResult Edit(MaterialModel material)
        {
            if (!ModelState.IsValid)
            {
                return View(_materialService.GetEntityById(material.Id).ToModel());
            }

            _materialService.Update(material.ToEntity());

            return RedirectToAction("Index");
        }
 
        public ActionResult Delete(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var material = _materialService.GetEntityById(id);

            if (material == null)
            {
                ViewBag.Error = MmResources.MaterialNotFound;
                return View();
            }

            return View(material.ToModel());
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var material = _materialService.GetEntityById(id);

            if (material == null)
            {
                ViewBag.Error = MmResources.MaterialNotFound;
                return View();
            }

            _materialService.Delete(material);

            return RedirectToAction("Index");
        }
    }
}