using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_g23.Migrations
{
    public partial class DropTableMotivations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Motivations_GroupId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "Motivations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
