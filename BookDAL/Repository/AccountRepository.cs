using BookWebApp.Models;
using BookWebApp.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BookWebApp.Repository
{
    public class AccountRepository : IAccountRepository
    {

        #region Consructor and varaibles
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;
        

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }
        #endregion
        /// <summary>
        ///  assigning the values of new user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        #region public methods
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = userModel.FirstName,
                LastName  = userModel.LastName,
                Email     = userModel.Email,
                UserName  = userModel.Email

            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            
            return result;
        }

        /// <summary>
        /// checks whether the logged in details are valid
        /// </summary>
        /// <param name="signInModel"></param>
        /// <returns></returns>
        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            return await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        /// <summary>
        /// change password method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }
        #endregion
    }
}
