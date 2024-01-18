using bizland.business.Exceptions;
using bizland.business.Services.Interfaces;
using bizland.business.ViewModels;
using bizland.core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bizland.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(loginViewModel loginView)
        {
            if (!ModelState.IsValid)
            {
                return View(loginView);
            }
            try
            {
                await _accountService.Login(loginView);
            }
            catch(InvalidCreadExceptions ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(loginView);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(loginView);
            }
           

            return RedirectToAction("index", "team");
        }
    }
}
