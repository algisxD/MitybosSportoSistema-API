using Microsoft.EntityFrameworkCore.Migrations;

namespace MitybosSportoSistema_API.Data.Migrations
{
    public partial class UpdateMenuRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ValgiarasciaiReceptai",
                table: "ValgiarasciaiReceptai");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ValgiarasciaiReceptai",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValgiarasciaiReceptai",
                table: "ValgiarasciaiReceptai",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ValgiarasciaiReceptai_ReceptasId",
                table: "ValgiarasciaiReceptai",
                column: "ReceptasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ValgiarasciaiReceptai",
                table: "ValgiarasciaiReceptai");

            migrationBuilder.DropIndex(
                name: "IX_ValgiarasciaiReceptai_ReceptasId",
                table: "ValgiarasciaiReceptai");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ValgiarasciaiReceptai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValgiarasciaiReceptai",
                table: "ValgiarasciaiReceptai",
                columns: new[] { "ReceptasId", "ValgiarastisId" });
        }
    }
}
