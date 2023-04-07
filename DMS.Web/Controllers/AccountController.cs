using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DMS.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly ILogger<HomeController> _logger;

        public AccountController(ILogger<HomeController> logger, INotyfService notyf)
        {
            _logger = logger;
            _notyf = notyf;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Login()
        //{
        //    var identity = new ClaimsIdentity(new[]
        //    {
        //        new Claim(ClaimTypes.Name, string.Empty),
        //        new Claim(ClaimTypes.GivenName,string.Empty),
        //        new Claim(ClaimTypes.Email, string.Empty)
        //    }, CookieAuthenticationDefaults.AuthenticationScheme);
        //    var principal = new ClaimsPrincipal(identity);

        //    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        //    _notyf.Success("Login Successful");
        //    return RedirectToAction("Index", "Home");
        //}

        //[Authorize]
        //public IActionResult Logout()
        //{
        //    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return RedirectToAction("Login");
        //}
    }
}
