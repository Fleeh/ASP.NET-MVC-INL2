using System.ComponentModel.DataAnnotations;

namespace ASPNETWEBCORE.Models
{
    public class SignInModel
    {
        public SignInModel()
        {
            Email = "";
            Password = "";
            ReturnUrl = "/";
        }

        [Display(Name = "Email Address")] 
        [Required(ErrorMessage = "You have to enter a email")]
        [EmailAddress(ErrorMessage = "The email address must be valid")]
        public string Email { get; set; }

        [Display(Name ="Password")]
        [Required(ErrorMessage = "You have to enter a password")]
        [StringLength(256, ErrorMessage = "Your password must be atleast 8 signs long", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
