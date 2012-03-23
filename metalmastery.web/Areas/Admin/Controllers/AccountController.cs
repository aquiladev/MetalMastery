using System;
using System.Linq;
using System.Web.Mvc;
using MetalMastery.Services.Interfaces;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Areas.Admin.Models;

namespace MetalMastery.Web.Areas.Admin.Controllers
{
    public class AccountController : BaseAdminController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public ViewResult Index()
        {
            return View(_userService.GetAll(0, 10)
                .Select(x => x.ToModel())
                .ToList());
        }

        public ActionResult Edit(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                ViewBag.Error = MmResources.IdEmptyError;
                return View();
            }

            UserModel user = _userService.GetEntityById(id).ToModel();

            if (user == null)
            {
                ViewBag.Error = MmResources.UserNotFound;
                return View();
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(_userService.GetEntityById(user.Id).ToModel());
            }

            _userService.Update(user);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var user = _userService.GetEntityById(id);

            if (user == null)
            {
                ViewBag.Error = MmResources.UserNotFound;
                return View();
            }

            return View(user.ToModel());
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var user = _userService.GetEntityById(id);

            if (user == null)
            {
                ViewBag.Error = MmResources.UserNotFound;
                return View();
            }

            _userService.Delete(user);

            return RedirectToAction("Index");
        }
    }
}