using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_g23.Migrations
{
    public partial class removeEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "action_type",
                table: "Actions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Actions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Actions",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "action_type",
                table: "Actions",
                nullable: false,
                defaultValue: "");
        }
    }
}