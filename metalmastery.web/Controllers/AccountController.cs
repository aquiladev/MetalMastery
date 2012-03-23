using System.Collections.Generic;
using System.Web.Mvc;
using MetalMastery.Core.Domain;
using MetalMastery.Core.Mvc;
using MetalMastery.Services.Interfaces;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Framework.Filters;
using MetalMastery.Web.Models;

namespace MetalMastery.Web.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
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

        [CheckModelFilter]
        public JsonResult SignIn(SignInModel user)
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

        [CheckModelFilter]
        public JsonResult SignUp(SignUpModel user)
        {
            if (_userService.GetUserByEmail(user.Email) != null)
            {
                return new MmJsonResult(
                    data: null,
                    success: false,
                    errors: new List<string> { MmResources.DublicateUser });
            }

            _userService.Insert(user.ToEntity());

            _emailSender.SendEmail(
                MmResources.CongratulationSbjTemplate, 
                string.Format(MmResources.CongratulationMsgTemplate, user.Email), 
                user.Email, user.Email);

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
