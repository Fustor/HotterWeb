using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HotterWeb.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_AspNetUsers_EmployeeId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestOff_AspNetUsers_EmployeeId",
                table: "RequestOff");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_AspNetUsers_EmployeeId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_UnavailableTime_AspNetUsers_EmployeeId",
                table: "UnavailableTime");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "UnavailableTime",
                newName: "IdNumber");

            migrationBuilder.RenameIndex(
                name: "IX_UnavailableTime_EmployeeId",
                table: "UnavailableTime",
                newName: "IX_UnavailableTime_IdNumber");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Schedule",
                newName: "IdNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_EmployeeId",
                table: "Schedule",
                newName: "IX_Schedule_IdNumber");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "RequestOff",
                newName: "IdNumber");

            migrationBuilder.RenameIndex(
                name: "IX_RequestOff_EmployeeId",
                table: "RequestOff",
                newName: "IX_RequestOff_IdNumber");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Job",
                newName: "IdNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Job_EmployeeId",
                table: "Job",
                newName: "IX_Job_IdNumber");

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_IdNumber",
                table: "AspNetUsers",
                column: "IdNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_AspNetUsers_IdNumber",
                table: "Job",
                column: "IdNumber",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestOff_AspNetUsers_IdNumber",
                table: "RequestOff",
                column: "IdNumber",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_AspNetUsers_IdNumber",
                table: "Schedule",
                column: "IdNumber",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnavailableTime_AspNetUsers_IdNumber",
                table: "UnavailableTime",
                column: "IdNumber",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_AspNetUsers_IdNumber",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestOff_AspNetUsers_IdNumber",
                table: "RequestOff");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_AspNetUsers_IdNumber",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_UnavailableTime_AspNetUsers_IdNumber",
                table: "UnavailableTime");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_IdNumber",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "UnavailableTime",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_UnavailableTime_IdNumber",
                table: "UnavailableTime",
                newName: "IX_UnavailableTime_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "Schedule",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_IdNumber",
                table: "Schedule",
                newName: "IX_Schedule_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "RequestOff",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestOff_IdNumber",
                table: "RequestOff",
                newName: "IX_RequestOff_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "Job",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_IdNumber",
                table: "Job",
                newName: "IX_Job_EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Job_AspNetUsers_EmployeeId",
                table: "Job",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestOff_AspNetUsers_EmployeeId",
                table: "RequestOff",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_AspNetUsers_EmployeeId",
                table: "Schedule",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnavailableTime_AspNetUsers_EmployeeId",
                table: "UnavailableTime",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
