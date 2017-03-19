using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_g23.Migrations
{
    public partial class AddPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostForeignKey",
                table: "Labels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostForeignKey",
                table: "Motivations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Announcement = table.Column<string>(nullable: false),
                    GroupForeignKey = table.Column<int>(nullable: false),
                    Logo = table.Column<byte[]>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Groups_GroupForeignKey",
                        column: x => x.GroupForeignKey,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labels_PostForeignKey",
                table: "Labels",
                column: "PostForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motivations_PostForeignKey",
                table: "Motivations",
                column: "PostForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GroupForeignKey",
                table: "Posts",
                column: "GroupForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_OrganizationId",
                table: "Posts",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motivations_Posts_PostForeignKey",
                table: "Motivations",
                column: "PostForeignKey",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Posts_PostForeignKey",
                table: "Labels",
                column: "PostForeignKey",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motivations_Posts_PostForeignKey",
                table: "Motivations");

            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Posts_PostForeignKey",
                table: "Labels");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Labels_PostForeignKey",
                table: "Labels");

            migrationBuilder.DropIndex(
                name: "IX_Motivations_PostForeignKey",
                table: "Motivations");

            migrationBuilder.DropColumn(
                name: "PostForeignKey",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "PostForeignKey",
                table: "Motivations");
        }
    }
}
