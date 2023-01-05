using ConsoleApp1.Models;
using Microsoft.AspNetCore.Identity;

namespace ConsoleApp1.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();

        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);

        //Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
    }
}