﻿using ConsoleApp1.Models;
using ConsoleApp1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        /// <summary>
        /// returning view for signing up new user
        /// </summary>
        /// <returns></returns>
        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }
        /// <summary>
        /// api for posting signing up details
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View(userModel);
                }

                ModelState.Clear();
                return View();
            }
            return View(userModel);
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid credentials");
                //if (result.IsNotAllowed)
                //{
                //    ModelState.AddModelError("", "Not allowed to login");
                //}
                //else
                //{
                //    ModelState.AddModelError("", "Invalid credentials");
                //}
            }

            return View(signInModel);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("change-password")]
        public IActionResult ChangePassword()
        { 
            return View();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePasswordAsync(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }

        //[HttpGet("confirm-email")]
        //public async Task<IActionResult> ConfirmEmail(string uid, string token)
        //{

        //    if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
        //    {
        //        token = token.Replace(' ', '+');
        //        var result = await _accountRepository.ConfirmEmailAsync(uid, token);
        //        if (result.Succeeded)
        //        {
        //            ViewBag.IsSuccess = true;
        //        }
        //    }

        //    return View();

        //}

    }
}
