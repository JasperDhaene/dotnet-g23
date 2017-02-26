using dotnet_g23.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_g23.Data
{
    public class ApplicationDbContext : DbContext
    {
        // GiveADay database entities
        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        // User hierarchy
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Lector> Lectors { get; set; }

        public DbSet<Group> Groups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // GiveADay database entities
            builder.Entity<User>(MapUser);
            builder.Entity<Organization>(MapOrganization);

            // User hierarchy
            builder.Entity<UserRole>()
                .HasDiscriminator<string>("user_role_type")
                .HasValue<Participant>("user_role_participant")
                .HasValue<Lector>("user_role_lector");
            builder.Entity<Participant>(MapParticipant);
            builder.Entity<Lector>(MapLector);

            builder.Entity<Group>(MapGroup);
            builder.Entity<Motivation>(MapMotivation);
        }

        private static void MapUser(EntityTypeBuilder<User> u)
        {
            u.ToTable("User");
            u.HasKey(user => user.UserId);
            u.Property(user => user.Email).IsRequired();

            // Email is unique
            u.HasAlternateKey(user => user.Email);

            u.HasOne(user => user.UserRole)
                .WithOne(userRole => userRole.User)
                .HasForeignKey<UserRole>(userRole => userRole.UserRoleId);
        }

        private static void MapOrganization(EntityTypeBuilder<Organization> o)
        {
            o.ToTable("Organizations");
            o.HasKey(org => org.OrganizationId);

            o.Property(org => org.Name).IsRequired();
            o.Property(org => org.Location).IsRequired();

            o.HasMany(org => org.Groups)
                .WithOne(g => g.Organization);
        }

        private static void MapParticipant(EntityTypeBuilder<Participant> p)
        {
            p.ToTable("Participants");

            p.HasOne(participant => participant.Organization)
                .WithMany(org => org.Participants)
                .IsRequired();
            p.HasOne(participant => participant.Group)
                .WithMany(g => g.Participants);
            p.HasOne(participant => participant.Lector)
                .WithMany(l => l.Participants);
        }

        private static void MapLector(EntityTypeBuilder<Lector> l)
        {
            l.ToTable("Lectors");

            l.HasMany(lector => lector.Participants)
                .WithOne(p => p.Lector);
            l.HasOne(lector => lector.Group)
                .WithMany(g => g.Lectors);
        }

        private static void MapGroup(EntityTypeBuilder<Group> g)
        {
            g.ToTable("Groups");
            g.HasKey(gr => gr.GroupId);
            g.Property(gr => gr.Name).IsRequired();
            g.Property(gr => gr.Closed).IsRequired();

            // Name is unique
            g.HasAlternateKey(gr => gr.Name);

            g.HasMany(group => group.Participants)
                .WithOne(p => p.Group);
            g.HasMany(group => group.Lectors)
                .WithOne(l => l.Group);
            g.HasOne(group => group.Organization)
                .WithMany(org => org.Groups);
            g.HasOne(group => group.Motivation)
                .WithOne(m => m.Group);
        }

        private static void MapMotivation(EntityTypeBuilder<Motivation> m)
        {
            m.ToTable("Motivations");
            m.HasKey(mo => mo.MotivationId);

            m.Property(mo => mo.Approved).IsRequired();
            m.Property(mo => mo.MotivationText).IsRequired();
            m.Property(mo => mo.OrganizationName).IsRequired();
            m.Property(mo => mo.OrganizationAddress).IsRequired();
            m.Property(mo => mo.OrganizationWebsite).IsRequired();
            m.Property(mo => mo.OrganizationEmail).IsRequired();

            m.Property(mo => mo.OrganizationContactTitle);
            m.Property(mo => mo.OrganizationContactFirstName);
            m.Property(mo => mo.OrganizationContactName);
            m.Property(mo => mo.OrganizationContactEmail);

            m.HasOne(mo => mo.Group)
                .WithOne(g => g.Motivation)
                .HasForeignKey<Group>(g => g.GroupId);
        }
    }
}
