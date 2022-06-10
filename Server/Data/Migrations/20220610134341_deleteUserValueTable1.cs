using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDevelopment.Server.Data.Migrations
{
    public partial class deleteUserValueTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserValues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserValues_Value_ValueId",
                        column: x => x.ValueId,
                        principalTable: "Value",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserValues_ValueId",
                table: "UserValues",
                column: "ValueId");
        }
    }
}
