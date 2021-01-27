using Microsoft.EntityFrameworkCore.Migrations;

namespace MitybosSportoSistema_API.Data.Migrations
{
    public partial class AddIngridientaiAndReceptai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProduktasId",
                table: "Ingridientai",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingridientai_ProduktasId",
                table: "Ingridientai",
                column: "ProduktasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingridientai_Produktai_ProduktasId",
                table: "Ingridientai",
                column: "ProduktasId",
                principalTable: "Produktai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingridientai_Produktai_ProduktasId",
                table: "Ingridientai");

            migrationBuilder.DropIndex(
                name: "IX_Ingridientai_ProduktasId",
                table: "Ingridientai");

            migrationBuilder.DropColumn(
                name: "ProduktasId",
                table: "Ingridientai");
        }
    }
}
