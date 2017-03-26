using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_g23.Migrations
{
    public partial class CreateBaseSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AspNetUsers",
                table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetUsers", x => x.Id); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.UniqueConstraint("AK_Users_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                "Organizations",
                table => new
                {
                    OrganizationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Domain = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Organizations", x => x.OrganizationId); });

            migrationBuilder.CreateTable(
                "AspNetRoles",
                table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetUserTokens",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints:
                table => { table.PrimaryKey("PK_AspNetUserTokens", x => new {x.UserId, x.LoginProvider, x.Name}); });

            migrationBuilder.CreateTable(
                "AspNetUserClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUserClaims_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserLogins",
                table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new {x.LoginProvider, x.ProviderKey});
                    table.ForeignKey(
                        "FK_AspNetUserLogins_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserRoles",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Invitations",
                table => new
                {
                    InvitationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: true),
                    ParticipantUserStateId = table.Column<int>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Invitations", x => x.InvitationId); });

            migrationBuilder.CreateTable(
                "Motivations",
                table => new
                {
                    MotivationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Approved = table.Column<bool>(nullable: false),
                    GroupForeignKey = table.Column<int>(nullable: false),
                    MotivationText = table.Column<string>(nullable: true),
                    OrganizationAddress = table.Column<string>(nullable: true),
                    OrganizationContactEmail = table.Column<string>(nullable: true),
                    OrganizationContactFirstName = table.Column<string>(nullable: true),
                    OrganizationContactName = table.Column<string>(nullable: true),
                    OrganizationContactTitle = table.Column<string>(nullable: true),
                    OrganizationEmail = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true),
                    OrganizationWebsite = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Motivations", x => x.MotivationId); });

            migrationBuilder.CreateTable(
                "UserStates",
                table => new
                {
                    UserStateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserForeignKey = table.Column<int>(nullable: false),
                    user_state_type = table.Column<string>(nullable: false),
                    GroupId = table.Column<int>(nullable: true),
                    LectorUserStateId = table.Column<int>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStates", x => x.UserStateId);
                    table.ForeignKey(
                        "FK_UserStates_Users_UserForeignKey",
                        x => x.UserForeignKey,
                        "Users",
                        "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserStates_UserStates_LectorUserStateId",
                        x => x.LectorUserStateId,
                        "UserStates",
                        "UserStateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_UserStates_Organizations_OrganizationId",
                        x => x.OrganizationId,
                        "Organizations",
                        "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Groups",
                table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Closed = table.Column<bool>(nullable: false),
                    LectorUserStateId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false),
                    StateContext = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.UniqueConstraint("AK_Groups_Name", x => x.Name);
                    table.ForeignKey(
                        "FK_Groups_UserStates_LectorUserStateId",
                        x => x.LectorUserStateId,
                        "UserStates",
                        "UserStateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Groups_Organizations_OrganizationId",
                        x => x.OrganizationId,
                        "Organizations",
                        "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "AspNetUsers",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Groups_LectorUserStateId",
                "Groups",
                "LectorUserStateId");

            migrationBuilder.CreateIndex(
                "IX_Groups_OrganizationId",
                "Groups",
                "OrganizationId");

            migrationBuilder.CreateIndex(
                "IX_Invitations_GroupId",
                "Invitations",
                "GroupId");

            migrationBuilder.CreateIndex(
                "IX_Invitations_ParticipantUserStateId",
                "Invitations",
                "ParticipantUserStateId");

            migrationBuilder.CreateIndex(
                "IX_Motivations_GroupForeignKey",
                "Motivations",
                "GroupForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_UserStates_UserForeignKey",
                "UserStates",
                "UserForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_UserStates_GroupId",
                "UserStates",
                "GroupId");

            migrationBuilder.CreateIndex(
                "IX_UserStates_LectorUserStateId",
                "UserStates",
                "LectorUserStateId");

            migrationBuilder.CreateIndex(
                "IX_UserStates_OrganizationId",
                "UserStates",
                "OrganizationId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName");

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleClaims_RoleId",
                "AspNetRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserClaims_UserId",
                "AspNetUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserLogins_UserId",
                "AspNetUserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_RoleId",
                "AspNetUserRoles",
                "RoleId");

            migrationBuilder.AddForeignKey(
                "FK_Invitations_UserStates_ParticipantUserStateId",
                "Invitations",
                "ParticipantUserStateId",
                "UserStates",
                principalColumn: "UserStateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Invitations_Groups_GroupId",
                "Invitations",
                "GroupId",
                "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Motivations_Groups_GroupForeignKey",
                "Motivations",
                "GroupForeignKey",
                "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_UserStates_Groups_GroupId",
                "UserStates",
                "GroupId",
                "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Groups_UserStates_LectorUserStateId",
                "Groups");

            migrationBuilder.DropTable(
                "Invitations");

            migrationBuilder.DropTable(
                "Motivations");

            migrationBuilder.DropTable(
                "AspNetRoleClaims");

            migrationBuilder.DropTable(
                "AspNetUserClaims");

            migrationBuilder.DropTable(
                "AspNetUserLogins");

            migrationBuilder.DropTable(
                "AspNetUserRoles");

            migrationBuilder.DropTable(
                "AspNetUserTokens");

            migrationBuilder.DropTable(
                "AspNetRoles");

            migrationBuilder.DropTable(
                "AspNetUsers");

            migrationBuilder.DropTable(
                "UserStates");

            migrationBuilder.DropTable(
                "Users");

            migrationBuilder.DropTable(
                "Groups");

            migrationBuilder.DropTable(
                "Organizations");
        }
    }
}