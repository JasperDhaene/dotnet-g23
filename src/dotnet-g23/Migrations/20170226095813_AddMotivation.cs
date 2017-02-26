using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_g23.Migrations
{
    public partial class AddMotivation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Groups",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "Motivations",
                columns: table => new
                {
                    MotivationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Approved = table.Column<bool>(nullable: false),
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
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Motivations_GroupId",
                table: "Groups",
                column: "GroupId",
                principalTable: "Motivations",
                principalColumn: "MotivationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Motivations_GroupId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "Motivations");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Groups",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
