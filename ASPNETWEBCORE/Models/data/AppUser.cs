using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ASPNETWEBCORE.Models.data
{
    public class AppUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string FirstName { get; set; }


        [Required]
        [PersonalData]
        public string LastName { get; set; }
    }

}
