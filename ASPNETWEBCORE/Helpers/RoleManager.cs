using ASPNETWEBCORE.Models.data;
using Microsoft.EntityFrameworkCore;
/*
namespace ASPNETWEBCORE.Helpers
{


    public interface IRoleManager
    {
        Task<IEnumerable<Role2>> GetRoleAsync();
        Task<Role2> GetUserRoleAsync(AppUser user);
        Task CreateRoleSync(AppUser user, Role2 roles);
    }

    public class RoleManager : IRoleManager
    {
        private readonly AppDbContext _context;

        public RoleManager(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoleSync(AppUser user, Role2 role)
        {
            var userRole = new Roles();

            var _role = await _context.Role2.FirstOrDefaultAsync(x => x.Name == role.Name && x.NormalizedName == role.NormalizedName);
            if (_role == null)
            {
                _context.Role2.Add(role);
                await _context.SaveChangesAsync();

                userRole = new Roles { UserId = user.Id, RoleId = role.Id };
            }
            else
            {
                userRole = new Roles { UserId = user.Id, RoleId = _role.Id };
            }

            _context.Role.Add(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role2>> GetRoleAsync()
        {
            return await _context.Role2.ToListAsync();
        }

        public async Task<Role2> GetUserRoleAsync(AppUser user)
        {
            var result = await _context.Role.Include(t => t.Role2).FirstOrDefaultAsync(x => x.UserId == user.Id);
            return result.Role2;
        }
    }
}
*/