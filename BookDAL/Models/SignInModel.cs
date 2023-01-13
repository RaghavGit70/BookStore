using System.ComponentModel.DataAnnotations;

namespace BookWebApp.Models
{
    /// <summary>
    /// model to specify field of user trying to login
    /// </summary>
    public class SignInModel
    {
        
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
