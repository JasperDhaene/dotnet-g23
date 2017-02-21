using dotnet_g23.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_g23.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<GADUser> GADUsers { get; set; }

        // UserRoles
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Group> Groups { get; set; }
        //public DbSet<GADOrganization> GADOrganizations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GADUser>(MapGADUser);
            builder.Entity<Volunteer>().ToTable("Volunteers");
            builder.Entity<Participant>().ToTable("Participants");
            builder.Entity<Lector>().ToTable("Lectors");
            builder.Entity<UserRole>()
                .HasDiscriminator<string>("user_role_type")
                .HasValue<Volunteer>("user_role_volunteer")
                .HasValue<Participant>("user_role_participant")
                .HasValue<Lector>("user_role_lector");

            builder.Entity<Group>(MapGroup);
            //builder.Entity<GADOrganization>(MapGADOrganization);
        }

        private static void MapGADUser(EntityTypeBuilder<GADUser> u)
        {
            u.ToTable("GADUser");
            u.HasKey(gu => gu.UserId);
            u.HasOne(gu => gu.UserRole);
        }

        private static void MapGroup(EntityTypeBuilder<Group> g)
        {
            g.ToTable("Groups");
            g.HasKey(gr => gr.GroupId);
        }

        /*private static void MapGADOrganization(EntityTypeBuilder<GADOrganization> u)
        {
            u.ToTable("GADOrganization");
            u.HasKey(o => o.OrganizationId);
            u.HasOne(o => o.OrganizationRole)
                .WithOne();
        }*/
    }
}
