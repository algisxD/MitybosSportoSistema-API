using Microsoft.EntityFrameworkCore.Migrations;

namespace MitybosSportoSistema_API.Data.Migrations
{
    public partial class MenuRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receptai_Valgiarasciai_ValgiarastisId",
                table: "Receptai");

            migrationBuilder.DropIndex(
                name: "IX_Receptai_ValgiarastisId",
                table: "Receptai");

            migrationBuilder.DropColumn(
                name: "ValgiarastisId",
                table: "Receptai");

            migrationBuilder.CreateTable(
                name: "ValgiarasciaiReceptai",
                columns: table => new
                {
                    ReceptasId = table.Column<int>(nullable: false),
                    ValgiarastisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValgiarasciaiReceptai", x => new { x.ReceptasId, x.ValgiarastisId });
                    table.ForeignKey(
                        name: "FK_ValgiarasciaiReceptai_Receptai_ReceptasId",
                        column: x => x.ReceptasId,
                        principalTable: "Receptai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValgiarasciaiReceptai_Valgiarasciai_ValgiarastisId",
                        column: x => x.ValgiarastisId,
                        principalTable: "Valgiarasciai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValgiarasciaiReceptai_ValgiarastisId",
                table: "ValgiarasciaiReceptai",
                column: "ValgiarastisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValgiarasciaiReceptai");

            migrationBuilder.AddColumn<int>(
                name: "ValgiarastisId",
                table: "Receptai",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receptai_ValgiarastisId",
                table: "Receptai",
                column: "ValgiarastisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receptai_Valgiarasciai_ValgiarastisId",
                table: "Receptai",
                column: "ValgiarastisId",
                principalTable: "Valgiarasciai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
