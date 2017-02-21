using dotnet_g23.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_g23.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<GADUser> GADUsers { get; set; }
        public DbSet<GADOrganization> GADOrganizations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<GADUser>(MapGADUser);
            builder.Entity<GADOrganization>(MapGADOrganization);
        }

        private static void MapGADUser(EntityTypeBuilder<GADUser> u)
        {
            u.ToTable("GADUser");
            u.HasKey(gu => gu.UserId);
            u.HasOne(gu => gu.UserRole)
                .WithOne();
        }

        private static void MapGADOrganization(EntityTypeBuilder<GADOrganization> u)
        {
            u.ToTable("GADOrganization");
            u.HasKey(o => o.OrganizationId);
            u.HasOne(o => o.OrganizationRole)
                .WithOne();
        }
    }
}
