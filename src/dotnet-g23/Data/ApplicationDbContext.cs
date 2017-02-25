using dotnet_g23.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_g23.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> GADUsers { get; set; }

        // UserRole
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Organization> GADOrganizations { get; set; }

        // OrganizationRole
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<GBOrganization> GBOrganizations { get; set; }
        public DbSet<OrganizationRole> OrganizationRoles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(MapGADUser);
            builder.Entity<Volunteer>().ToTable("Volunteers");
            builder.Entity<Participant>().ToTable("Participants");
            builder.Entity<Lector>().ToTable("Lectors");
            builder.Entity<UserRole>()
                .HasDiscriminator<string>("user_role_type")
                .HasValue<Volunteer>("user_role_volunteer")
                .HasValue<Participant>("user_role_participant")
                .HasValue<Lector>("user_role_lector");
            builder.Entity<Group>(MapGroup);

            builder.Entity<Organization>(MapGADOrganization);
            builder.Entity<Organization>().ToTable("Organizations");
            builder.Entity<GBOrganization>().ToTable("GBOrganizations");
            builder.Entity<OrganizationRole>()
                .HasDiscriminator<string>("organization_role_type")
                .HasValue<Organization>("organization_role_organization")
                .HasValue<GBOrganization>("organization_role_gb_organization");
        }

        private static void MapGADUser(EntityTypeBuilder<User> u)
        {
            u.ToTable("User");
            u.HasKey(gu => gu.UserId);
        }

        private static void MapGroup(EntityTypeBuilder<Group> g)
        {
            g.ToTable("Groups");
            g.HasKey(gr => gr.GroupId);
        }

        private static void MapGADOrganization(EntityTypeBuilder<Organization> u)
        {
            u.ToTable("Organization");
            u.HasKey(o => o.OrganizationId);
            u.HasOne(o => o.OrganizationRole);
        }
    }
}
