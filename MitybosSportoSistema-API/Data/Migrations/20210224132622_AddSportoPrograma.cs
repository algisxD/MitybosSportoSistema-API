using Microsoft.EntityFrameworkCore.Migrations;

namespace MitybosSportoSistema_API.Data.Migrations
{
    public partial class SportoPrograma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SavaitesDiena",
                table: "Treniruotes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SportoProgramaId",
                table: "Treniruotes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SportoPrograma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pavadinimas = table.Column<string>(nullable: true),
                    VartotojasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportoPrograma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportoPrograma_Vartotojai_VartotojasId",
                        column: x => x.VartotojasId,
                        principalTable: "Vartotojai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treniruotes_SportoProgramaId",
                table: "Treniruotes",
                column: "SportoProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_SportoPrograma_VartotojasId",
                table: "SportoPrograma",
                column: "VartotojasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treniruotes_SportoPrograma_SportoProgramaId",
                table: "Treniruotes",
                column: "SportoProgramaId",
                principalTable: "SportoPrograma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treniruotes_SportoPrograma_SportoProgramaId",
                table: "Treniruotes");

            migrationBuilder.DropTable(
                name: "SportoPrograma");

            migrationBuilder.DropIndex(
                name: "IX_Treniruotes_SportoProgramaId",
                table: "Treniruotes");

            migrationBuilder.DropColumn(
                name: "SavaitesDiena",
                table: "Treniruotes");

            migrationBuilder.DropColumn(
                name: "SportoProgramaId",
                table: "Treniruotes");
        }
    }
}
