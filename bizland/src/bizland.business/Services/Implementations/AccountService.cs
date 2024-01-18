using bizland.business.Exceptions;
using bizland.business.Services.Interfaces;
using bizland.business.ViewModels;
using bizland.core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task Login(loginViewModel loginView)
        {
            AppUser admin = null;
            admin = await _userManager.FindByNameAsync(loginView.UserName);
            if (admin == null)
            {
                throw new InvalidCreadExceptions("", "Username or password incorrect!");

            }
            var result = await _signInManager.PasswordSignInAsync(admin, loginView.Password, false, false);
            if (!result.Succeeded)
            {
                throw new InvalidCreadExceptions("", "Username or password incorrect!");
            }

        }
    }
}
