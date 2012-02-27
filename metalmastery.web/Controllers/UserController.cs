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
            var encoder = new ASCIIEncoding();
            byte[] pwd = encoder.GetBytes(user.Password);

            if (_userService.ValidateUser(user.Email, pwd))
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

        [CheckModelFilter]
        public JsonResult SignUp(RegistrateModel user)
        {
            byte[] pwd = Encoding.ASCII.GetBytes(user.Password);  

            _userService.InsertUser(new User
                                        {
                                            Email = user.Email,
                                            Password = pwd
                                        });
            //TODO: Добавить вменяемый шаблон
            //_emailSender.SendEmail("Праздравляю, зарегались Вы!", "зарегались", string.Empty, string.Empty, user.Email, user.Email);
            return new MmJsonResult(data: null);
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
