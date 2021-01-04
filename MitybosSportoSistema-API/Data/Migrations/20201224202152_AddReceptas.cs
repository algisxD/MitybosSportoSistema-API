using Microsoft.EntityFrameworkCore.Migrations;

namespace MitybosSportoSistema_API.Data.Migrations
{
    public partial class AddReceptas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceptasId",
                table: "Produktai",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Receptai",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pavadinimas = table.Column<string>(nullable: true),
                    Nuotrauka = table.Column<string>(nullable: true),
                    Aprasymas = table.Column<string>(nullable: true),
                    GaminimoLaikas = table.Column<int>(nullable: false),
                    PorcijuSkaicius = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptai", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produktai_ReceptasId",
                table: "Produktai",
                column: "ReceptasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produktai_Receptai_ReceptasId",
                table: "Produktai",
                column: "ReceptasId",
                principalTable: "Receptai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produktai_Receptai_ReceptasId",
                table: "Produktai");

            migrationBuilder.DropTable(
                name: "Receptai");

            migrationBuilder.DropIndex(
                name: "IX_Produktai_ReceptasId",
                table: "Produktai");

            migrationBuilder.DropColumn(
                name: "ReceptasId",
                table: "Produktai");
        }
    }
}
