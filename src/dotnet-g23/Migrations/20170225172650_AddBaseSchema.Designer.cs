using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using dotnet_g23.Data;

namespace dotnet_g23.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170225172650_AddBaseSchema")]
    partial class AddBaseSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dotnet_g23.Models.Domain.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Closed");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("OrganizationId");

                    b.HasKey("GroupId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.UserRole", b =>
                {
                    b.Property<int>("UserRoleId");

                    b.Property<string>("user_role_type")
                        .IsRequired();

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");

                    b.HasDiscriminator<string>("user_role_type").HasValue("UserRole");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Lector", b =>
                {
                    b.HasBaseType("dotnet_g23.Models.Domain.UserRole");

                    b.Property<int?>("GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("Lectors");

                    b.HasDiscriminator().HasValue("user_role_lector");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Participant", b =>
                {
                    b.HasBaseType("dotnet_g23.Models.Domain.UserRole");

                    b.Property<int?>("GroupId");

                    b.Property<int?>("LectorUserRoleId");

                    b.Property<int?>("OrganizationId")
                        .IsRequired();

                    b.HasIndex("GroupId");

                    b.HasIndex("LectorUserRoleId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Participants");

                    b.HasDiscriminator().HasValue("user_role_participant");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Group", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.Organization", "Organization")
                        .WithMany("Groups")
                        .HasForeignKey("OrganizationId");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.UserRole", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.User", "User")
                        .WithOne("UserRole")
                        .HasForeignKey("dotnet_g23.Models.Domain.UserRole", "UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Lector", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.Group", "Group")
                        .WithMany("Lectors")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("dotnet_g23.Models.Domain.Participant", b =>
                {
                    b.HasOne("dotnet_g23.Models.Domain.Group", "Group")
                        .WithMany("Participants")
                        .HasForeignKey("GroupId");

                    b.HasOne("dotnet_g23.Models.Domain.Lector", "Lector")
                        .WithMany("Participants")
                        .HasForeignKey("LectorUserRoleId");

                    b.HasOne("dotnet_g23.Models.Domain.Organization", "Organization")
                        .WithMany("Participants")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
