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

            builder.Entity<Group>(MapGroup);
            builder.Entity<Motivation>(MapMotivation);
        }

        private static void MapUser(EntityTypeBuilder<GUser> u)
        {
            u.ToTable("User");
            u.HasKey(user => user.UserId);
            u.Property(user => user.Email).IsRequired();

            // Email is unique
            u.HasAlternateKey(user => user.Email);

            u.HasOne(user => user.UserState)
                .WithOne(userState => userState.User)
                .HasForeignKey<UserState>(userState => userState.UserStateId);
        }

        public static void MapUserState(EntityTypeBuilder<UserState> u) {
            u.ToTable("UserState");
            u.HasKey(userState => userState.UserStateId);
            u.HasDiscriminator<string>("user_state_type")
                .HasValue<Participant>("user_state_participant")
                .HasValue<Lector>("user_state_lector");
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

            //p.HasKey(participant => participant.ParticipantId);
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

            //l.HasKey(lector => lector.LectorId);
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
