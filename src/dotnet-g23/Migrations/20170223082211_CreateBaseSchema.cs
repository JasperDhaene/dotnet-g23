﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnetg23.Migrations
{
    public partial class CreateBaseSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationRoles",
                columns: table => new
                {
                    OrganizationRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    organization_role_type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationRoles", x => x.OrganizationRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OrganizationRoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GADOrganization", x => x.OrganizationId);
                    table.ForeignKey(
                        name: "FK_GADOrganization_OrganizationRoles_OrganizationRoleId",
                        column: x => x.OrganizationRoleId,
                        principalTable: "OrganizationRoles",
                        principalColumn: "OrganizationRoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GBOrganizationOrganizationRoleId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Groups_OrganizationRoles_GBOrganizationOrganizationRoleId",
                        column: x => x.GBOrganizationOrganizationRoleId,
                        principalTable: "OrganizationRoles",
                        principalColumn: "OrganizationRoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_role_type = table.Column<string>(nullable: false),
                    GBOrganizationOrganizationRoleId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    LectorUserRoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRoles_OrganizationRoles_GBOrganizationOrganizationRoleId",
                        column: x => x.GBOrganizationOrganizationRoleId,
                        principalTable: "OrganizationRoles",
                        principalColumn: "OrganizationRoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_UserRoles_LectorUserRoleId",
                        column: x => x.LectorUserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    UserRoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GADUser", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_GADUser_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GADOrganization_OrganizationRoleId",
                table: "Organization",
                column: "OrganizationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_GADUser_UserRoleId",
                table: "User",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GBOrganizationOrganizationRoleId",
                table: "Groups",
                column: "GBOrganizationOrganizationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_GBOrganizationOrganizationRoleId",
                table: "UserRoles",
                column: "GBOrganizationOrganizationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_GroupId",
                table: "UserRoles",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_LectorUserRoleId",
                table: "UserRoles",
                column: "LectorUserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "OrganizationRoles");
        }
    }
}
