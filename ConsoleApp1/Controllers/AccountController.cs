using BookDAL.Models;
using BookWebApp.Models;
using BookWebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApp.Controllers
{
    public class AccountController : Controller
    {
        #region Consructor and varaibles
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        #endregion

        #region Signup api
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
        #endregion

        #region login api
        /// <summary>
        /// returning view for login page
        /// </summary>
        /// <returns></returns>

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// api for posting log in details and verifying user
        /// </summary>
        /// <param name="signInModel"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>

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
            }

            return View(signInModel);
        }
        #endregion

        #region logout api
        /// <summary>
        /// api for user to logout
        /// </summary>
        /// <returns></returns>

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region change-password api
        [Route("change-password")]
        public IActionResult ChangePassword()
        { 
            return View();
        }

        /// <summary>
        /// method for changing user password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

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
        #endregion
    }
}
