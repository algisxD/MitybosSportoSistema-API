using Microsoft.EntityFrameworkCore.Migrations;

namespace MitybosSportoSistema_API.Data.Migrations
{
    public partial class AddPratimai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pratimai",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pavadinimas = table.Column<string>(nullable: true),
                    Aprasymas = table.Column<string>(nullable: true),
                    SerijuSkaicius = table.Column<int>(nullable: false),
                    PakartojimuSkaicius = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pratimai", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pratimai");
        }
    }
}
