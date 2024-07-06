using Giftos.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giftos.Services
{
    public class IdentityDataContext : IdentityDbContext<User>
    {
        public IdentityDataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<String>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<String>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<String>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<String>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserToken<String>>().ToTable("UserTokens");
        }
    }
}
