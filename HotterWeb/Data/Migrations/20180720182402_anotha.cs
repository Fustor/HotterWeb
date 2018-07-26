using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HotterWeb.Data.Migrations
{
    public partial class anotha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Job_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestOff",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    DayOff = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOff", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RequestOff_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ClockIn = table.Column<string>(nullable: true),
                    ClockOut = table.Column<string>(nullable: true),
                    Day = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Schedule_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnavailableTime",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BeginningTime = table.Column<string>(nullable: true),
                    Day = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: false),
                    EndTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnavailableTime", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UnavailableTime_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Job_EmployeeId",
                table: "Job",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOff_EmployeeId",
                table: "RequestOff",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_EmployeeId",
                table: "Schedule",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UnavailableTime_EmployeeId",
                table: "UnavailableTime",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "RequestOff");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "UnavailableTime");
        }
    }
}
