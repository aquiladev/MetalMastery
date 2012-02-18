using System;
using System.Linq;
using System.Web.Mvc;
using MetalMastery.Admin.App_LocalResources;
using MetalMastery.Admin.Models;
using MetalMastery.Services;

namespace MetalMastery.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ViewResult Index()
        {
            return View(_userService.GetAllUsers(0, 10)
                .Select(x => x.ToModel())
                .ToList());
        }

        public ActionResult Edit(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                ViewBag.Error = MmAdminResources.IdEmptyError;
                return View();
            }

            UserModel user = _userService.GetUserById(id).ToModel();
            ViewBag.PossibleRoles = _userService.GetAllRoles();

            if (user == null)
            {
                ViewBag.Error = MmAdminResources.UserDidntFound;
                return View();
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.PossibleRoles = _userService.GetAllRoles();
                return View(_userService.GetUserById(user.Id).ToModel());
            }

            _userService.UpdateUser(user);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var user = _userService.GetUserById(id);

            if (user == null)
            {
                ViewBag.Error = MmAdminResources.UserDidntFound;
                return View();
            }

            return View(user.ToModel());
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var user = _userService.GetUserById(id);

            if (user == null)
            {
                ViewBag.Error = MmAdminResources.UserDidntFound;
                return View();
            }

            _userService.DeleteUser(user);

            return RedirectToAction("Index");
        }
    }
}