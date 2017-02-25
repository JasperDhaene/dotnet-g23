using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using dotnet_g23.Data;

namespace dotnetg23.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dotnet_g23.Models.Domain.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<int?>("OrganizationRoleId");

                    b.HasKey("OrganizationId");

                    b.HasIndex("OrganizationRoleId");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int?>("UserRoleId");

                    b.HasKey("UserId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GBOrganizationOrganizationRoleId");

                    b.Property<string>("Name");

                    b.HasKey("GroupId");

                    b.HasIndex("GBOrganizationOrganizationRoleId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.OrganizationRole", b =>
                {
                    b.Property<int>("OrganizationRoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("organization_role_type")
                        .IsRequired();

                    b.HasKey("OrganizationRoleId");

                    b.ToTable("OrganizationRoles");

                    b.HasDiscriminator<string>("organization_role_type").HasValue("OrganizationRole");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("user_role_type")
                        .IsRequired();

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");

                    b.HasDiscriminator<string>("user_role_type").HasValue("UserRole");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.GBOrganization", b =>
                {
                    b.HasBaseType("dotnet_g23.Models.Domain.OrganizationRole");


                    b.ToTable("GBOrganizations");

                    b.HasDiscriminator().HasValue("organization_role_gb_organization");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Organization", b =>
                {
                    b.HasBaseType("dotnet_g23.Models.Domain.OrganizationRole");


                    b.ToTable("Organizations");

                    b.HasDiscriminator().HasValue("organization_role_organization");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Lector", b =>
                {
                    b.HasBaseType("dotnet_g23.Models.Domain.UserRole");


                    b.ToTable("Lectors");

                    b.HasDiscriminator().HasValue("user_role_lector");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Participant", b =>
                {
                    b.HasBaseType("dotnet_g23.Models.Domain.UserRole");

                    b.Property<int?>("GBOrganizationOrganizationRoleId");

                    b.Property<int?>("GroupId");

                    b.Property<int?>("LectorUserRoleId");

                    b.HasIndex("GBOrganizationOrganizationRoleId");

                    b.HasIndex("GroupId");

                    b.HasIndex("LectorUserRoleId");

                    b.ToTable("Participants");

                    b.HasDiscriminator().HasValue("user_role_participant");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Volunteer", b =>
                {
                    b.HasBaseType("dotnet_g23.Models.Domain.UserRole");


                    b.ToTable("Volunteers");

                    b.HasDiscriminator().HasValue("user_role_volunteer");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Organization", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.OrganizationRole", "OrganizationRole")
                        .WithMany()
                        .HasForeignKey("OrganizationRoleId");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.User", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Group", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.GBOrganization", "GBOrganization")
                        .WithMany("Groups")
                        .HasForeignKey("GBOrganizationOrganizationRoleId");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Participant", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.GBOrganization", "GBOrganization")
                        .WithMany("Participants")
                        .HasForeignKey("GBOrganizationOrganizationRoleId");

                    b.HasOne("dotnet_g23.Models.Domain.Group", "Group")
                        .WithMany("Participants")
                        .HasForeignKey("GroupId");

                    b.HasOne("dotnet_g23.Models.Domain.Lector", "Lector")
                        .WithMany("Participants")
                        .HasForeignKey("LectorUserRoleId");
                });
        }
    }
}
