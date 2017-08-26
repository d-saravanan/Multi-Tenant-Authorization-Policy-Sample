using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WingTailApp.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WingTailApp.Services;
using MT.Framework.Core.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WingTailApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        public AccountController(IUserAuthenticationService userAuthenticationService) { _userAuthenticationService = userAuthenticationService; }

        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Login(string errorMsg = null) { return View(); }

        [AllowAnonymous]
        public async Task<IActionResult> SignIn(LoginViewModel loginViewModel)
        {
            if (null == loginViewModel || string.IsNullOrWhiteSpace(loginViewModel.UserName) || string.IsNullOrWhiteSpace(loginViewModel.Password))
            {
                return RedirectToAction("Login", new { errorMsg = "Empty login details" });
            }

            var validatedUser = _userAuthenticationService.IsValidUser(loginViewModel.TenantName, loginViewModel.UserName, loginViewModel.Password);

            if (null == validatedUser) return RedirectToAction("Login", new { errorMsg = "Invalid Credentials" });

            var id = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Upn,validatedUser.UserName),
                    new Claim(ClaimTypes.NameIdentifier, validatedUser.UserId.ToString()),
                    new Claim(CustomClaimTypes.TenantIdClaim, validatedUser.TenantId.ToString())
                }, "CookieAuth");
            await HttpContext.SignInAsync(new ClaimsPrincipal(id));
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");
        }
    }
}
