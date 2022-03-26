using ASPNETWEBCORE.Models.data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPNETWEBCORE.Models.data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<ImageEntity> Images { get; set; }
        public virtual DbSet<ServiceEntity> Services { get; set; }
        public virtual DbSet<ApplicationAddress> Addresses { get; set; }
        public virtual DbSet<ApplicationUserAddress> UserAddresses { get; set; }
        /*
        public virtual DbSet<Role2> Role2 { get; set; }
        public virtual DbSet<Roles> Role { get; set; }
        */



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserAddress>()
                .HasKey(c => new { c.UserId, c.AddressId });

            //modelBuilder.Entity<Roles>()
            //   .HasKey(c => new { c.UserId, c.RoleId });

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey("LoginProvider", "ProviderKey");

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey("UserId", "RoleId");

            modelBuilder.Entity<IdentityUserToken<string>>()
               .HasKey("UserId", "LoginProvider", "Name");
            


            
        }

        

        
    }
    
}
