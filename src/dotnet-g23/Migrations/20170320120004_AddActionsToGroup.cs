using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_g23.Migrations
{
    public partial class AddActionsToGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "GroupId",
                "Actions",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_Actions_GroupId",
                "Actions",
                "GroupId");

            migrationBuilder.AddForeignKey(
                "FK_Actions_Groups_GroupId",
                "Actions",
                "GroupId",
                "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Actions_Groups_GroupId",
                "Actions");

            migrationBuilder.DropIndex(
                "IX_Actions_GroupId",
                "Actions");

            migrationBuilder.DropColumn(
                "GroupId",
                "Actions");
        }
    }
}