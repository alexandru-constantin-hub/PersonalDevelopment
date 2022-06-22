using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDevelopment.Server.Data.Migrations
{
    public partial class AddDateTimeToTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Taks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeLimit",
                table: "Taks",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Taks");

            migrationBuilder.DropColumn(
                name: "TimeLimit",
                table: "Taks");
        }
    }
}
