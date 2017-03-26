using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_g23.Migrations
{
    public partial class removePostLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "MotivationText",
                table: "Motivations",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "Companies",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Actions",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Companies");

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "Posts",
                nullable: false,
                defaultValue: new byte[] {});

            migrationBuilder.AlterColumn<string>(
                name: "MotivationText",
                table: "Motivations",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Actions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}