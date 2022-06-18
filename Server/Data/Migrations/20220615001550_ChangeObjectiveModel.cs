using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDevelopment.Server.Data.Migrations
{
    public partial class ChangeObjectiveModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Objectives");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Objectives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
