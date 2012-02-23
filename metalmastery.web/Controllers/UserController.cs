using System.Collections.Generic;
using System.Web.Mvc;
using MetalMastery.Core.Domain;
using MetalMastery.Core.Mvc;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Framework.Filters;
using MetalMastery.Web.Models;
using MetalMastery.Services;

namespace MetalMastery.Web.Controllers
{
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
        public JsonResult LogIn(LogOnModel user)
        {
            if (_userService.ValidateUser(user.Email, user.Password))
            {
                _authenticationService.SignIn(
                    _userService.GetUserByEmail(user.Email),
                    user.RememberMe);
            }
            else
            {
                return new MmJsonResult(
                    data: null,
                    success: false,
                    errors: new List<string> { MmResources.LoginPasswordInvalid });
            }

            return new MmJsonResult(data: null);
        }

        [CheckModelFilter]
        public JsonResult LogOn(RegistrateModel user)
        {
            var role = _userService.GetRoleByName(Roles.Customer.ToString());

            if (role == null)
            {
                return new MmJsonResult(
                    data: null,
                    success: false,
                    errors: new List<string> { MmResources.RoleNotFound });
            }
            _userService.InsertUser(new User
                                        {
                                            Email = user.Email,
                                            Password = user.Password,
                                            RoleId = role.Id
                                        });
            //TODO: Добавить вменяемый шаблон
            //_emailSender.SendEmail("Праздравляю, зарегались Вы!", "зарегались", string.Empty, string.Empty, user.Email, user.Email);
            return new MmJsonResult(data: null);
        }

        public JsonResult IsAuthenticate()
        {
            return new MmJsonResult(data: new
                                              {
                                                  User.Identity.IsAuthenticated,
                                                  IsAdmin = User.IsInRole(Roles.Administrator.ToString())
                                              });
        }

        public JsonResult LogOut()
        {
            _authenticationService.SignOut();
            return new MmJsonResult(data: null);
        }

        ////
        //// GET: /User/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        ////
        //// GET: /User/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /User/Create

        //public ActionResult Create()
        //{
        //    return View();
        //} 

        ////
        //// POST: /User/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /User/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /User/Edit/5

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /User/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /User/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
