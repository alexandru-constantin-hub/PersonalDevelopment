using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDevelopment.Server.Data.Migrations
{
    public partial class ObjectiveModelAddTimeLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeLimit",
                table: "Objectives",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeLimit",
                table: "Objectives");
        }
    }
}
