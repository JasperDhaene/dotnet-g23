using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using dotnet_g23.Data;

namespace dotnet_g23.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170315162709_AddDescriptionToCompany")]
    partial class AddDescriptionToCompany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dotnet_g23.Models.Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Website")
                        .IsRequired();

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyId")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Function")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ContactId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Closed");

                    b.Property<int?>("LectorUserStateId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("OrganizationId")
                        .IsRequired();

                    b.Property<string>("StateContext")
                        .IsRequired();

                    b.HasKey("GroupId");

                    b.HasAlternateKey("Name");

                    b.HasIndex("LectorUserStateId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.GUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.HasAlternateKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Invitation", b =>
                {
                    b.Property<int>("InvitationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GroupId");

                    b.Property<int?>("ParticipantUserStateId");

                    b.HasKey("InvitationId");

                    b.HasIndex("GroupId");

                    b.HasIndex("ParticipantUserStateId");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Motivation", b =>
                {
                    b.Property<int>("MotivationId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Approved");

                    b.Property<int>("GroupForeignKey");

                    b.Property<string>("MotivationText")
                        .IsRequired();

                    b.Property<string>("OrganizationAddress")
                        .IsRequired();

                    b.Property<string>("OrganizationContactEmail");

                    b.Property<string>("OrganizationContactFirstName");

                    b.Property<string>("OrganizationContactName");

                    b.Property<string>("OrganizationContactTitle");

                    b.Property<string>("OrganizationEmail")
                        .IsRequired();

                    b.Property<string>("OrganizationName")
                        .IsRequired();

                    b.Property<string>("OrganizationWebsite")
                        .IsRequired();

                    b.HasKey("MotivationId");

                    b.HasIndex("GroupForeignKey")
                        .IsUnique();

                    b.ToTable("Motivations");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Domain")
                        .IsRequired();

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.UserState", b =>
                {
                    b.Property<int>("UserStateId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserForeignKey");

                    b.Property<string>("user_state_type")
                        .IsRequired();

                    b.HasKey("UserStateId");

                    b.HasIndex("UserForeignKey")
                        .IsUnique();

                    b.ToTable("UserStates");

                    b.HasDiscriminator<string>("user_state_type").HasValue("UserState");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Lector", b =>
                {
                    b.HasBaseType("dotnet_g23.Models.Domain.UserState");


                    b.ToTable("Lectors");

                    b.HasDiscriminator().HasValue("user_state_lector");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Participant", b =>
                {
                    b.HasBaseType("dotnet_g23.Models.Domain.UserState");

                    b.Property<int?>("GroupId");

                    b.Property<int?>("LectorUserStateId");

                    b.Property<int?>("OrganizationId")
                        .IsRequired();

                    b.HasIndex("GroupId");

                    b.HasIndex("LectorUserStateId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Participants");

                    b.HasDiscriminator().HasValue("user_state_participant");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Contact", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.Company", "Company")
                        .WithMany("Contacts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Group", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.Lector", "Lector")
                        .WithMany("Groups")
                        .HasForeignKey("LectorUserStateId");

                    b.HasOne("dotnet_g23.Models.Domain.Organization", "Organization")
                        .WithMany("Groups")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Invitation", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.Group", "Group")
                        .WithMany("Invitations")
                        .HasForeignKey("GroupId");

                    b.HasOne("dotnet_g23.Models.Domain.Participant", "Participant")
                        .WithMany("Invitations")
                        .HasForeignKey("ParticipantUserStateId");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Motivation", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.Group", "Group")
                        .WithOne("Motivation")
                        .HasForeignKey("dotnet_g23.Models.Domain.Motivation", "GroupForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.UserState", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.GUser", "User")
                        .WithOne("UserState")
                        .HasForeignKey("dotnet_g23.Models.Domain.UserState", "UserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("dotnet_g23.Models.Domain.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Participant", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.Group", "Group")
                        .WithMany("Participants")
                        .HasForeignKey("GroupId");

                    b.HasOne("dotnet_g23.Models.Domain.Lector", "Lector")
                        .WithMany("Participants")
                        .HasForeignKey("LectorUserStateId");

                    b.HasOne("dotnet_g23.Models.Domain.Organization", "Organization")
                        .WithMany("Participants")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
