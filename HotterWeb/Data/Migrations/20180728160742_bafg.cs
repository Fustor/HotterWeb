using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HotterWeb.Data.Migrations
{
    public partial class bafg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Schedule",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdNumber = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manager_AspNetUsers_IdNumber",
                        column: x => x.IdNumber,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manager_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_LocationName",
                table: "Schedule",
                column: "LocationName");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_IdNumber",
                table: "Manager",
                column: "IdNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_LocationId",
                table: "Manager",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Location_LocationName",
                table: "Schedule",
                column: "LocationName",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Location_LocationName",
                table: "Schedule");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_LocationName",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Schedule");
        }
    }
}
