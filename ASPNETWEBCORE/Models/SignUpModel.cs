using System.ComponentModel.DataAnnotations;

namespace ASPNETWEBCORE.Models
{
    public class SignUpModel
    {

        public SignUpModel()
        {
            Email = "";
            Password = "";
            ConfirmPassword = "";
            FirstName = "";
            LastName = "";
            AddressLine = "";
            PostalCode = "";
            City = "";
            ReturnUrl = "/";
            RoleName = "user";
        }


        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You have to enter a email")]
        [EmailAddress(ErrorMessage = "The email address must be valid")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You have to enter a password")]
        [StringLength(256, ErrorMessage = "Your password must be atleast 8 signs", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm")]
        [Required(ErrorMessage = "You have to confirm your password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "You have to enter a firstname")]
        [StringLength(256, ErrorMessage = "Your firstname must be atleast 2 signs", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "You have to enter a lastname")]
        [StringLength(256, ErrorMessage = "Your lastname must be atleast 2 signs", MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Addressline")]
        [Required(ErrorMessage = "You have to enter an address")]
        [StringLength(256, ErrorMessage = "Your address must be atleast 2 signs", MinimumLength = 2)]
        public string AddressLine { get; set; }

        [Display(Name = "Postalcode")]
        [Required(ErrorMessage = "You have to enter a postalcode")]
        [StringLength(256, ErrorMessage = "Your address must be atleast 5 signs", MinimumLength = 5)]
        public string PostalCode { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "You have to enter a city")]
        [StringLength(256, ErrorMessage = "Your address must be atleast 2 signs", MinimumLength = 2)]
        public string City { get; set; }

        public string ErrorMessage { get; set; } = "";
        public string ReturnUrl { get; set; } = "/";

        public string RoleName { get; set; } = "user";
    }
}
