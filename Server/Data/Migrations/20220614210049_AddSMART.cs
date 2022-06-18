using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDevelopment.Server.Data.Migrations
{
    public partial class AddSMART : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Achievable",
                table: "Objectives",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Objectives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Measurable",
                table: "Objectives",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Relevant",
                table: "Objectives",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Specific",
                table: "Objectives",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Time",
                table: "Objectives",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Achievable",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "Measurable",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "Relevant",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "Specific",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Objectives");
        }
    }
}
