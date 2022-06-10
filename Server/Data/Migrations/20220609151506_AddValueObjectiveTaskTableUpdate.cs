using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDevelopment.Server.Data.Migrations
{
    public partial class AddValueObjectiveTaskTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ValueObjectiveTaks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueID = table.Column<int>(type: "int", nullable: true),
                    ObjectiveID = table.Column<int>(type: "int", nullable: true),
                    TakID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueObjectiveTaks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValueObjectiveTaks_Objectives_ObjectiveID",
                        column: x => x.ObjectiveID,
                        principalTable: "Objectives",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValueObjectiveTaks_Taks_TakID",
                        column: x => x.TakID,
                        principalTable: "Taks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValueObjectiveTaks_Value_ValueID",
                        column: x => x.ValueID,
                        principalTable: "Value",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValueObjectiveTaks_ObjectiveID",
                table: "ValueObjectiveTaks",
                column: "ObjectiveID");

            migrationBuilder.CreateIndex(
                name: "IX_ValueObjectiveTaks_TakID",
                table: "ValueObjectiveTaks",
                column: "TakID");

            migrationBuilder.CreateIndex(
                name: "IX_ValueObjectiveTaks_ValueID",
                table: "ValueObjectiveTaks",
                column: "ValueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValueObjectiveTaks");
        }
    }
}
