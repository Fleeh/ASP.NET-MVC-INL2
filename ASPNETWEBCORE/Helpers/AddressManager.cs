using ASPNETWEBCORE.Models.data;
using Microsoft.EntityFrameworkCore;

namespace ASPNETWEBCORE.Helpers
{


    public interface IAddressManager
    {
        Task<IEnumerable<ApplicationAddress>> GetAddressesAsync();
        Task<ApplicationAddress> GetUserAddressAsync(AppUser user);
        Task CreateUserAddressAsync(AppUser user, ApplicationAddress address);
    }

    public class AddressManager : IAddressManager
    {
        private readonly AppDbContext _context;

        public AddressManager(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAddressAsync(AppUser user, ApplicationAddress address)
        {
            var userAddress = new ApplicationUserAddress();

            var _address = await _context.Addresses.FirstOrDefaultAsync(x => x.AddressLine == address.AddressLine && x.PostalCode == address.PostalCode);
            if(_address == null)
            {
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();

                userAddress = new ApplicationUserAddress { UserId = user.Id, AddressId = address.Id };
            }
            else
            {
                userAddress = new ApplicationUserAddress { UserId = user.Id, AddressId = _address.Id };
            }
                       
            _context.UserAddresses.Add(userAddress);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApplicationAddress>> GetAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<ApplicationAddress> GetUserAddressAsync(AppUser user)
        {
            var result = await _context.UserAddresses.Include(t => t.Address).FirstOrDefaultAsync(x => x.UserId == user.Id);
            return result.Address;
        }
    }
}
      