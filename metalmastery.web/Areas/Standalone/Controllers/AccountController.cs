using System.Web.Mvc;
using MetalMastery.Services.Interfaces;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Models;

namespace MetalMastery.Web.Areas.Standalone.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IEmailSender _emailSender;

        public AccountController(
            IAuthenticationService authenticationService,
            IUserService userService,
            IEmailSender emailSender)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _emailSender = emailSender;
        }

        public ActionResult SignIn(SignInModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (_userService.ValidateUser(user.Email, user.Password))
            {
                _authenticationService.SignIn(
                    _userService.GetUserByEmail(user.Email),
                    user.RememberMe);

                return RedirectToAction("Index", "Home", new { area = "" });
            }

            ViewBag.Error = MmResources.UserNotFound;
            return View();
        }

        public ActionResult SignUp(SignUpModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (_userService.GetUserByEmail(user.Email) != null)
            {
                ViewBag.Error = MmResources.DublicateUser;
                return View();
            }

            _userService.Insert(user.ToEntity());

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult SignOut()
        {
            _authenticationService.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
