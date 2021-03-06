﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HotterWeb.Data.Migrations
{
    public partial class agw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "Job",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Job_IdNumber",
                table: "Job",
                column: "IdNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_AspNetUsers_IdNumber",
                table: "Job",
                column: "IdNumber",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_AspNetUsers_IdNumber",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_IdNumber",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Job");
        }
    }
}
