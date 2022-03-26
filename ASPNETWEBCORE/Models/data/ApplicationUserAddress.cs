using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ASPNETWEBCORE.Models.data
{
    public class ApplicationUserAddress
    {
        public string UserId { get; set; }

        public int AddressId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ApplicationAddress Address { get; set; }
    }
}