using System;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.State;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationUser = dotnet_g23.Models.Domain.ApplicationUser;

namespace dotnet_g23.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        // GiveADay database entities
        public DbSet<GUser> GUsers { get; private set; }
        public DbSet<Organization> Organizations { get; private set; }

        // User hierarchy
        public DbSet<UserState> UserStates { get; private set; }
        public DbSet<Participant> Participants { get; private set; }
        public DbSet<Lector> Lectors { get; private set; }
        public DbSet<Motivation> Motivations { get; private set; }
        public DbSet<Invitation> Invitations { get; private set; }

        public DbSet<Group> Groups { get; private set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            // GiveADay database entities
            builder.Entity<GUser>(MapGUser);
            builder.Entity<Organization>(MapOrganization);

            // User hierarchy
            builder.Entity<UserState>(MapUserState);
            builder.Entity<Participant>(MapParticipant);
            builder.Entity<Lector>(MapLector);
            builder.Entity<Invitation>(MapInvitation);

            builder.Entity<Group>(MapGroup);
            builder.Entity<Motivation>(MapMotivation);
        }

        private static void MapGUser(EntityTypeBuilder<GUser> u) {
            u.ToTable("Users");
            u.HasKey(user => user.UserId);

            u.Property(user => user.Email).IsRequired();

            u.HasAlternateKey(user => user.Email);
        }

        public static void MapUserState(EntityTypeBuilder<UserState> us) {
            us.ToTable("UserStates");
            us.HasKey(userState => userState.UserStateId);

            us.HasDiscriminator<string>("user_state_type")
                .HasValue<Participant>("user_state_participant")
                .HasValue<Lector>("user_state_lector");

            // GUser => UserState
            us.HasOne(userState => userState.User)
                .WithOne(u => u.UserState)
                .HasForeignKey<UserState>(userState => userState.UserForeignKey)
                .IsRequired();
        }

        private static void MapOrganization(EntityTypeBuilder<Organization> o) {
            o.ToTable("Organizations");
            o.HasKey(org => org.OrganizationId);

            o.Property(org => org.Name).IsRequired();
            o.Property(org => org.Location).IsRequired();
            o.Property(org => org.Domain).IsRequired();
        }

        private static void MapParticipant(EntityTypeBuilder<Participant> p) {
            p.ToTable("Participants");

            // Participant => Organization
            p.HasOne(pa => pa.Organization)
                .WithMany(o => o.Participants)
                .IsRequired();

            // Participant => Group
            p.HasOne(pa => pa.Group)
                .WithMany(g => g.Participants);

            // Participant => Lector
            p.HasOne(participant => participant.Lector)
                .WithMany(l => l.Participants);
        }

        private static void MapLector(EntityTypeBuilder<Lector> l) {
            l.ToTable("Lectors");
        }

        private static void MapInvitation(EntityTypeBuilder<Invitation> i) {
            i.ToTable("Invitations");
            i.HasKey(no => no.InvitationId);

            i.Property(no => no.Message).IsRequired();
            i.Property(no => no.DateCreated).IsRequired();
            i.Property(no => no.DateRead);
            i.Property(no => no.IsRead).IsRequired();

            // Invitation => GUser
            i.HasOne(inv => inv.Participant)
                .WithMany(u => u.Invitations);

            // Invitation => Group
            i.HasOne(inv => inv.Group)
                .WithMany(g => g.Invitations);
        }

        private static void MapGroup(EntityTypeBuilder<Group> g) {
            g.ToTable("Groups");
            g.HasKey(gr => gr.GroupId);

            g.Property(gr => gr.Name).IsRequired();
            g.Property(gr => gr.Closed).IsRequired();

            g.HasAlternateKey(gr => gr.Name);

            // Group => Organization
            g.HasOne(gr => gr.Organization)
                .WithMany(o => o.Groups)
                .IsRequired();

            // Group => Lector
            g.HasOne(gr => gr.Lector)
                .WithMany(l => l.Groups);

            // Group => Context
            /*g.HasOne(gr => gr.Context)
                .WithOne(c => c.Group)
                .HasForeignKey<Group>(gr => gr.ContextForeignKey)
                .IsRequired();*/
        }

        private static void MapMotivation(EntityTypeBuilder<Motivation> m) {
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

            // Motivation => Group
            m.HasOne(mo => mo.Group)
                .WithOne(g => g.Motivation)
                .HasForeignKey<Motivation>(mo => mo.GroupForeignKey)
                .IsRequired();
        }
    }
}