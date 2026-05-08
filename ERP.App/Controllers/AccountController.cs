using ERP.Services.LoginService;
using ERP.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            //if (User.Identity?.IsAuthenticated == true)
            //    return RedirectToAction("Index", "Home");

            //ViewData["ReturnUrl"] = returnUrl;
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel model, string? returnUrl = null)
        {
            //ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return View("Login", model);

            var result = await _authService.LoginAsync(model);

            if (result.Succeeded)
            {
                //if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                //    return Redirect(returnUrl);
                return RedirectToAction("Index", "Home");
            }

            if (result.IsLockedOut)
                ModelState.AddModelError(string.Empty, "Account locked due to multiple failed attempts. Try again later.");
            else if (result.IsNotAllowed)
                ModelState.AddModelError(string.Empty, "Your account is inactive. Contact your administrator.");
            else
                ModelState.AddModelError(string.Empty, "Invalid email or password.");

            return View("Login", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutAsync()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Login");
        }
    }

}
