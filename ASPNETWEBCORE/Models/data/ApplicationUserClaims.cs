using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace ASPNETWEBCORE.Models.data
{
    public class ApplicationUserClaims : UserClaimsPrincipalFactory<AppUser, IdentityRole>
    {
        private readonly AppDbContext _context;

        public ApplicationUserClaims(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            _context = context;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);
            var address = await _context.UserAddresses.Include(x => x.Address).FirstOrDefaultAsync(x => x.UserId == user.Id);
            /*
            var roles = await _context.Role.Include(x => x.UserId).FirstOrDefaultAsync(x => x.UserId == user.Id);
            */


            claimsIdentity.AddClaim(new Claim("UserId", user.Id ?? ""));
            claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}" ?? ""));
            claimsIdentity.AddClaim(new Claim("Address", $"{address?.Address.AddressLine}, {address?.Address.PostalCode} {address?.Address.City}" ?? ""));
            /*
            claimsIdentity.AddClaim(new Claim("Role", $"{roles?.Role2.Name}" ?? ""));
            */
            return claimsIdentity;
        }


       
        }
    }

