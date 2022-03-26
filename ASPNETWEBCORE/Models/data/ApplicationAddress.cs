using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ASPNETWEBCORE.Models.data
{
    public class ApplicationAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [PersonalData]
        public string AddressLine { get; set; }

        [Required]
        [PersonalData]
        public string PostalCode { get; set; }

        [Required]
        [PersonalData]
        public string City { get; set; }
    }
}
