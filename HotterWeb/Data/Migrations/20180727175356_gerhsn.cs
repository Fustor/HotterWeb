using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HotterWeb.Data.Migrations
{
    public partial class gerhsn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestOff_AspNetUsers_IdNumber",
                table: "RequestOff");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_AspNetUsers_IdNumber",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_UnavailableTime_AspNetUsers_IdNumber",
                table: "UnavailableTime");

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "UnavailableTime",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "Schedule",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "RequestOff",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "Manager",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestOff_AspNetUsers_IdNumber",
                table: "RequestOff",
                column: "IdNumber",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_AspNetUsers_IdNumber",
                table: "Schedule",
                column: "IdNumber",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnavailableTime_AspNetUsers_IdNumber",
                table: "UnavailableTime",
                column: "IdNumber",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestOff_AspNetUsers_IdNumber",
                table: "RequestOff");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_AspNetUsers_IdNumber",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_UnavailableTime_AspNetUsers_IdNumber",
                table: "UnavailableTime");

            migrationBuilder.DropColumn(
                name: "Manager",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "UnavailableTime",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "Schedule",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "RequestOff",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
