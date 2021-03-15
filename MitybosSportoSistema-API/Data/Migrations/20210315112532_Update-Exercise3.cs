
using Microsoft.EntityFrameworkCore.Migrations;

namespace MitybosSportoSistema_API.Data.Migrations
{
    public partial class UpdateExercise3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VartotojasId",
                table: "Treniruotes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treniruotes_VartotojasId",
                table: "Treniruotes",
                column: "VartotojasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treniruotes_Vartotojai_VartotojasId",
                table: "Treniruotes",
                column: "VartotojasId",
                principalTable: "Vartotojai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treniruotes_Vartotojai_VartotojasId",
                table: "Treniruotes");

            migrationBuilder.DropIndex(
                name: "IX_Treniruotes_VartotojasId",
                table: "Treniruotes");

            migrationBuilder.DropColumn(
                name: "VartotojasId",
                table: "Treniruotes");
        }
    }
}
