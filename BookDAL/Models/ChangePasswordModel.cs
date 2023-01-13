using System.ComponentModel.DataAnnotations;

namespace BookWebApp.Models
{
    /// <summary>
    /// model for changing password
    /// </summary>
    public class ChangePasswordModel
    {
        
        public int Id { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Current password")]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "New password")]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Confirm new password does not match")]
        public string ConfirmNewPassword { get; set; }
    }
}
