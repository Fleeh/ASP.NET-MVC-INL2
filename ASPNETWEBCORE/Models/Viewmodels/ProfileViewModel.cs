using ASPNETWEBCORE.Models.data;

namespace ASPNETWEBCORE.Models.Viewmodels
{
    public class ProfileViewModel
    {
        public ApplicationUserAddress Address { get; set; }
        public AppUser User { get; set; }

    }
}
