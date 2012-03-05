using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using MetalMastery.Core.Domain;
using MetalMastery.Core.Mvc;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Framework.Filters;
using MetalMastery.Web.Models;
using MetalMastery.Services;

namespace MetalMastery.Web.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IEmailSender _emailSender;

        public UserController(
            IAuthenticationService authenticationService,
            IUserService userService,
            IEmailSender emailSender)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _emailSender = emailSender;
        }

        [CheckModelFilter]
        public JsonResult SignIn(LogOnModel user)
        {
            User authUser;

            if (_userService.ValidateUser(user.Email, user.Password))
            {
                authUser = _userService.GetUserByEmail(user.Email);
                _authenticationService.SignIn(
                    authUser,
                    user.RememberMe);
            }
            else
            {
                return new MmJsonResult(
                    data: null,
                    success: false,
                    errors: new List<string> { MmResources.LoginPasswordInvalid });
            }

            return new MmJsonResult(authUser.Email);
        }

        public ActionResult LogIn(LogOnModel user)
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

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = MmResources.UserNotFound;
            return View();
        }

        [CheckModelFilter]
        public JsonResult SignUp(RegistrateModel user)
        {
            byte[] pwd = Encoding.ASCII.GetBytes(user.Password);

            if (_userService.GetUserByEmail(user.Email) != null)
            {
                return new MmJsonResult(
                    data: null,
                    success: false,
                    errors: new List<string> { MmResources.DublicateUser });
            }

            _userService.InsertUser(new User
                                        {
                                            Email = user.Email,
                                            Password = pwd
                                        });
            //TODO: Добавить вменяемый шаблон
            //_emailSender.SendEmail("Праздравляю, зарегались Вы!", "зарегались", string.Empty, string.Empty, user.Email, user.Email);
            return new MmJsonResult(data: null);
        }

        public ActionResult LogOn(RegistrateModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            byte[] pwd = Encoding.ASCII.GetBytes(user.Password);

            if (_userService.GetUserByEmail(user.Email) != null)
            {
                ViewBag.Error = MmResources.DublicateUser;
                return View();
            }

            _userService.InsertUser(new User
                                        {
                                            Email = user.Email,
                                            Password = pwd
                                        });

            return RedirectToAction("Index", "Home");
        }

        public JsonResult IsAuthenticate()
        {
            return new MmJsonResult(new
                                        {
                                            User.Identity.IsAuthenticated,
                                            User = User.Identity.Name,
                                            IsAdmin = User.IsInRole(Roles.Administrator.ToString())
                                        });
        }

        public JsonResult SignOut()
        {
            _authenticationService.SignOut();
            return new MmJsonResult(data: null);
        }
    }
}
