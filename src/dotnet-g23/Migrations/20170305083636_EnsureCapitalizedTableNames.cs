using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_g23.Migrations
{
    public partial class EnsureCapitalizedTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_User_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserState_User_UserStateId",
                table: "UserState");

            migrationBuilder.DropForeignKey(
                name: "FK_UserState_Groups_GroupId",
                table: "UserState");

            migrationBuilder.DropForeignKey(
                name: "FK_UserState_UserState_LectorUserStateId",
                table: "UserState");

            migrationBuilder.DropForeignKey(
                name: "FK_UserState_Organizations_OrganizationId",
                table: "UserState");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserState",
                table: "UserState");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_User_Email",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "UserState",
                newName: "UserStates");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_UserState_OrganizationId",
                table: "UserStates",
                newName: "IX_UserStates_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_UserState_LectorUserStateId",
                table: "UserStates",
                newName: "IX_UserStates_LectorUserStateId");

            migrationBuilder.RenameIndex(
                name: "IX_UserState_GroupId",
                table: "UserStates",
                newName: "IX_UserStates_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserStates",
                table: "UserStates",
                column: "UserStateId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStates_Users_UserStateId",
                table: "UserStates",
                column: "UserStateId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStates_Groups_GroupId",
                table: "UserStates",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStates_UserStates_LectorUserStateId",
                table: "UserStates",
                column: "LectorUserStateId",
                principalTable: "UserStates",
                principalColumn: "UserStateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStates_Organizations_OrganizationId",
                table: "UserStates",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStates_Users_UserStateId",
                table: "UserStates");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStates_Groups_GroupId",
                table: "UserStates");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStates_UserStates_LectorUserStateId",
                table: "UserStates");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStates_Organizations_OrganizationId",
                table: "UserStates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserStates",
                table: "UserStates");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UserStates",
                newName: "UserState");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_UserStates_OrganizationId",
                table: "UserState",
                newName: "IX_UserState_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_UserStates_LectorUserStateId",
                table: "UserState",
                newName: "IX_UserState_LectorUserStateId");

            migrationBuilder.RenameIndex(
                name: "IX_UserStates_GroupId",
                table: "UserState",
                newName: "IX_UserState_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserState",
                table: "UserState",
                column: "UserStateId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_Email",
                table: "User",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_User_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserState_User_UserStateId",
                table: "UserState",
                column: "UserStateId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserState_Groups_GroupId",
                table: "UserState",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserState_UserState_LectorUserStateId",
                table: "UserState",
                column: "LectorUserStateId",
                principalTable: "UserState",
                principalColumn: "UserStateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserState_Organizations_OrganizationId",
                table: "UserState",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
