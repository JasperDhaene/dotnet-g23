using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_g23.Migrations
{
    public partial class AddActionAndEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Actions",
                table => new
                {
                    ActionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    action_type = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Actions", x => x.ActionId); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Actions");
        }
    }
}