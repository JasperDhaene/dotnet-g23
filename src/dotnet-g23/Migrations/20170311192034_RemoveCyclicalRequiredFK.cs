using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_g23.Migrations {
    public partial class RemoveCyclicalRequiredFK : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Groups_GroupId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_UserStates_ParticipantUserStateId",
                table: "Invitations");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipantUserStateId",
                table: "Invitations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Invitations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Groups_GroupId",
                table: "Invitations",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_UserStates_ParticipantUserStateId",
                table: "Invitations",
                column: "ParticipantUserStateId",
                principalTable: "UserStates",
                principalColumn: "UserStateId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Groups_GroupId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_UserStates_ParticipantUserStateId",
                table: "Invitations");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipantUserStateId",
                table: "Invitations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Invitations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Groups_GroupId",
                table: "Invitations",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_UserStates_ParticipantUserStateId",
                table: "Invitations",
                column: "ParticipantUserStateId",
                principalTable: "UserStates",
                principalColumn: "UserStateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}