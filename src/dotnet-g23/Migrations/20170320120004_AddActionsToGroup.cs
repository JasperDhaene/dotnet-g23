using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_g23.Migrations
{
    public partial class AddActionsToGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Actions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actions_GroupId",
                table: "Actions",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Groups_GroupId",
                table: "Actions",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Groups_GroupId",
                table: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Actions_GroupId",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Actions");
        }
    }
}