using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_g23.Migrations
{
    public partial class ReAddMotivations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motivations",
                columns: table => new
                {
                    MotivationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Approved = table.Column<bool>(nullable: false),
                    GroupForeignKey = table.Column<int>(nullable: false),
                    MotivationText = table.Column<string>(nullable: false),
                    OrganizationAddress = table.Column<string>(nullable: false),
                    OrganizationContactEmail = table.Column<string>(nullable: true),
                    OrganizationContactFirstName = table.Column<string>(nullable: true),
                    OrganizationContactName = table.Column<string>(nullable: true),
                    OrganizationContactTitle = table.Column<string>(nullable: true),
                    OrganizationEmail = table.Column<string>(nullable: false),
                    OrganizationName = table.Column<string>(nullable: false),
                    OrganizationWebsite = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivations", x => x.MotivationId);
                    table.ForeignKey(
                        name: "FK_Motivations_Groups_GroupForeignKey",
                        column: x => x.GroupForeignKey,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motivations_GroupForeignKey",
                table: "Motivations",
                column: "GroupForeignKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motivations");
        }
    }
}
