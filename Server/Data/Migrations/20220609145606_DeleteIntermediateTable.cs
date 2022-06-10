using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDevelopment.Server.Data.Migrations
{
    public partial class DeleteIntermediateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectiveTak");

            migrationBuilder.DropTable(
                name: "ObjectiveValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectiveTak",
                columns: table => new
                {
                    ObjectivesId = table.Column<int>(type: "int", nullable: false),
                    TaksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectiveTak", x => new { x.ObjectivesId, x.TaksId });
                    table.ForeignKey(
                        name: "FK_ObjectiveTak_Objectives_ObjectivesId",
                        column: x => x.ObjectivesId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectiveTak_Taks_TaksId",
                        column: x => x.TaksId,
                        principalTable: "Taks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectiveValue",
                columns: table => new
                {
                    ObjectivesId = table.Column<int>(type: "int", nullable: false),
                    ValuesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectiveValue", x => new { x.ObjectivesId, x.ValuesId });
                    table.ForeignKey(
                        name: "FK_ObjectiveValue_Objectives_ObjectivesId",
                        column: x => x.ObjectivesId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectiveValue_Value_ValuesId",
                        column: x => x.ValuesId,
                        principalTable: "Value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveTak_TaksId",
                table: "ObjectiveTak",
                column: "TaksId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveValue_ValuesId",
                table: "ObjectiveValue",
                column: "ValuesId");
        }
    }
}
