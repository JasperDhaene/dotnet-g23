using System;
using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationUser = dotnet_g23.Models.Domain.ApplicationUser;

namespace dotnet_g23.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // GiveADay database entities
        public DbSet<GUser> GUsers { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        // User hierarchy
        public DbSet<UserState> UserStates { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<Motivation> Motivations { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        public DbSet<Group> Groups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // GiveADay database entities
            builder.Entity<GUser>(MapUser);
            builder.Entity<Organization>(MapOrganization);

            // User hierarchy
            builder.Entity<UserState>(MapUserState);
            builder.Entity<Participant>(MapParticipant);
            builder.Entity<Lector>(MapLector);
            builder.Entity<Invitation>(MapInvitation);

            builder.Entity<Group>(MapGroup);
            builder.Entity<Motivation>(MapMotivation);
        }

        private static void MapUser(EntityTypeBuilder<GUser> u)
        {
            u.ToTable("Users");
            u.HasKey(user => user.UserId);

            u.Property(user => user.Email).IsRequired();

            // Email is unique
            u.HasAlternateKey(user => user.Email);

            u.HasOne(user => user.UserState)
                .WithOne(userState => userState.User)
                .HasForeignKey<UserState>(userState => userState.UserStateId);
        }

        public static void MapUserState(EntityTypeBuilder<UserState> us) {
            us.ToTable("UserStates");
            us.HasKey(userState => userState.UserStateId);

            us.HasDiscriminator<string>("user_state_type")
                .HasValue<Participant>("user_state_participant")
                .HasValue<Lector>("user_state_lector");

            us.HasOne(state => state.User)
                .WithOne(u => u.UserState)
                .IsRequired();
        }

        private static void MapOrganization(EntityTypeBuilder<Organization> o)
        {
            o.ToTable("Organizations");
            o.HasKey(org => org.OrganizationId);

            o.Property(org => org.Name).IsRequired();
            o.Property(org => org.Location).IsRequired();
            o.Property(org => org.Domain).IsRequired();

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

        private static void MapInvitation(EntityTypeBuilder<Invitation> n)
        {
            n.ToTable("Invitations");
            n.HasKey(no => no.InvitationId);

            n.Property(no => no.Message).IsRequired();
            n.Property(no => no.DateCreated).IsRequired();
            n.Property(no => no.DateRead);
            n.Property(no => no.IsRead).IsRequired();

            n.HasOne(no => no.User)
                .WithMany(u => u.Invitations)
                .IsRequired();
            n.HasOne(no => no.Group)
                .WithMany(g => g.Invitations)
                .IsRequired();
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
                .WithMany(org => org.Groups)
                .IsRequired();
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
                .HasForeignKey<Group>(g => g.GroupId)
                .IsRequired();
        }
    }
}
