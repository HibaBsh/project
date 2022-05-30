using BookManagement.Models;
using BookManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountServices;
        public AccountController(IAccountService _accountServices)
        {
            accountServices = _accountServices;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            SignUpViewModel vm = new SignUpViewModel();
            List<IdentityRole> liRole = accountServices.GetRoles();
            vm.LiRoles = liRole;
            return View("CreateAccount", vm);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAccount(SignUpViewModel signUpViewModel)
        {
            SignUpViewModel vm = new SignUpViewModel();
            List<IdentityRole> liRole = accountServices.GetRoles();
            vm.LiRoles = liRole;
            var result = await accountServices.CreateUser(signUpViewModel.signUpModel);

            return View("CreateAccount", vm);
        }
        public IActionResult SignIn()
        {
            return View("Login");
        }
        public async Task<IActionResult> SignOut()
        {
            await accountServices.Logout();
            return View("Login");
        }
        public async Task<IActionResult> Checkpassword(SignInModel signInModel)
        {
            var result = await accountServices.Checkpassword(signInModel);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Category");
            }
            else
            {
                ViewData["errorMessage"] = "Invalid Username or Password";
                return View("Login");
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult NewRole()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveRole(RoleModel roleModel)
        {
            var result = await accountServices.NewRole(roleModel);
            return View("NewRole");
        }
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

    }
}
