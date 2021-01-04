using Microsoft.EntityFrameworkCore.Migrations;

namespace MitybosSportoSistema_API.Data.Migrations
{
    public partial class AddTreniruote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreniruoteId",
                table: "Pratimai",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Treniruotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pavadinimas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treniruotes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pratimai_TreniruoteId",
                table: "Pratimai",
                column: "TreniruoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pratimai_Treniruotes_TreniruoteId",
                table: "Pratimai",
                column: "TreniruoteId",
                principalTable: "Treniruotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pratimai_Treniruotes_TreniruoteId",
                table: "Pratimai");

            migrationBuilder.DropTable(
                name: "Treniruotes");

            migrationBuilder.DropIndex(
                name: "IX_Pratimai_TreniruoteId",
                table: "Pratimai");

            migrationBuilder.DropColumn(
                name: "TreniruoteId",
                table: "Pratimai");
        }
    }
}
