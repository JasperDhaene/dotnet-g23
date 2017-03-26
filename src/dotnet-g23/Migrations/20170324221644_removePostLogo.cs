using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_g23.Migrations
{
    public partial class removePostLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Logo",
                "Posts");

            migrationBuilder.AlterColumn<string>(
                "MotivationText",
                "Motivations",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                "Logo",
                "Companies",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                "Date",
                "Actions",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Logo",
                "Companies");

            migrationBuilder.AddColumn<byte[]>(
                "Logo",
                "Posts",
                nullable: false,
                defaultValue: new byte[] {});

            migrationBuilder.AlterColumn<string>(
                "MotivationText",
                "Motivations",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                "Date",
                "Actions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}