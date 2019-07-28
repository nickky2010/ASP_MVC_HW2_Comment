using ASP_MVC_HW2_Comment.App_LocalResources;
using ASP_MVC_HW2_Comment.BLL.Infrastructure.Models;
using ASP_MVC_HW2_Comment.BLL.Interfaces;
using ASP_MVC_HW2_Comment.Filters;
using ASP_MVC_HW2_Comment.Models;
using ASP_MVC_HW2_Comment.Models.Account;
using ASP_MVC_HW2_Comment.Models.ViewModel;
using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_HW2_Comment.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        [Culture]
        public ActionResult Login()
        {
            if (AuthenticationManager.User.IsInRole("user") || AuthenticationManager.User.IsInRole("admin"))
                return RedirectToAction("Index", "Home");
            else
                return View();
        }
        [Culture]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                ClaimsIdentity claim = await UserService.AuthenticateAsync(Mapper.Map<LoginViewModel, UserDTO>(model));
                if (claim == null)
                {
                    ModelState.AddModelError("", Resource.WrongLoginPassword);
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [Culture]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }
        [Culture]
        public ActionResult Register()
        {
            return View();
        }

        [Culture]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                OperationDetails operationDetails = await UserService.CreateAsync(Mapper.Map<RegisterViewModel, UserDTO>(model));
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeLanguage(string langKey)
        {
            string returnUrl = Request.UrlReferrer.PathAndQuery;
            string lang = Languages.List[langKey];
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;
            else
            {
                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddDays(10);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialDataAsync(new UserDTO
            {
                Firstname = "Manko",
                Lastname = "Mikalai",
                Email = "nickky2010@mail.ru",
                Login = "nic_123",
                Password = "111111"
            });
        }
    }
}