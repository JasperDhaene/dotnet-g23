using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_g23.Migrations
{
    public partial class MoveInvitationsFromUserToParticipant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Users_UserId",
                table: "Invitations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Invitations",
                newName: "ParticipantUserStateId");

            migrationBuilder.RenameIndex(
                name: "IX_Invitations_UserId",
                table: "Invitations",
                newName: "IX_Invitations_ParticipantUserStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_UserStates_ParticipantUserStateId",
                table: "Invitations",
                column: "ParticipantUserStateId",
                principalTable: "UserStates",
                principalColumn: "UserStateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_UserStates_ParticipantUserStateId",
                table: "Invitations");

            migrationBuilder.RenameColumn(
                name: "ParticipantUserStateId",
                table: "Invitations",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invitations_ParticipantUserStateId",
                table: "Invitations",
                newName: "IX_Invitations_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Users_UserId",
                table: "Invitations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
