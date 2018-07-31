using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HotterWeb.Data.Migrations
{
    public partial class gav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Location_LocationName",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_LocationName",
                table: "Schedule");

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Schedule",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Schedule",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_LocationName",
                table: "Schedule",
                column: "LocationName");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Location_LocationName",
                table: "Schedule",
                column: "LocationName",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
