using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HotterWeb.Data.Migrations
{
    public partial class nybr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "UnavailableTime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "RequestOff",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "UnavailableTime");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "RequestOff");
        }
    }
}
