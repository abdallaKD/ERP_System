using ERP.Domain.Models;
using ERP.Services.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services.LoginService
{
    public class AuthService : IAuthService
    {
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;

        public AuthService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            var isActive = await IsUserActiveAsync(model.Email);
            if (!isActive)
                return SignInResult.NotAllowed;

            return await _signInManager.PasswordSignInAsync(
                userName: model.Email,
                password: model.Password,
                isPersistent: model.RememberMe,
                lockoutOnFailure: true
            );
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<bool> IsUserActiveAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user is { IsActive: true };
        }
    }
}
