using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDevelopment.Server.Data.Migrations
{
    public partial class AddValueObjectiveANDObjectiveTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectiveTaks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectiveID = table.Column<int>(type: "int", nullable: true),
                    TakID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectiveTaks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ObjectiveTaks_Objectives_ObjectiveID",
                        column: x => x.ObjectiveID,
                        principalTable: "Objectives",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObjectiveTaks_Taks_TakID",
                        column: x => x.TakID,
                        principalTable: "Taks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ValueObjective",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueID = table.Column<int>(type: "int", nullable: true),
                    ObjectiveID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueObjective", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ValueObjective_Objectives_ObjectiveID",
                        column: x => x.ObjectiveID,
                        principalTable: "Objectives",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValueObjective_Value_ValueID",
                        column: x => x.ValueID,
                        principalTable: "Value",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveTaks_ObjectiveID",
                table: "ObjectiveTaks",
                column: "ObjectiveID");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveTaks_TakID",
                table: "ObjectiveTaks",
                column: "TakID");

            migrationBuilder.CreateIndex(
                name: "IX_ValueObjective_ObjectiveID",
                table: "ValueObjective",
                column: "ObjectiveID");

            migrationBuilder.CreateIndex(
                name: "IX_ValueObjective_ValueID",
                table: "ValueObjective",
                column: "ValueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectiveTaks");

            migrationBuilder.DropTable(
                name: "ValueObjective");
        }
    }
}
