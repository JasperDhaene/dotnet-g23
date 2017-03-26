using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_g23.Migrations
{
    public partial class AddDescriptionToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "Description",
                "Companies",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Description",
                "Companies");
        }
    }
}