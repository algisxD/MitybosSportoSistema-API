using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MitybosSportoSistema_API.Data.Migrations
{
    public partial class UpdatesportoProgramaAndTreniruote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SukurimoData",
                table: "Treniruotes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TreniruotesTipas",
                table: "Treniruotes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SukurimoData",
                table: "SportoPrograma",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SukurimoData",
                table: "Treniruotes");

            migrationBuilder.DropColumn(
                name: "TreniruotesTipas",
                table: "Treniruotes");

            migrationBuilder.DropColumn(
                name: "SukurimoData",
                table: "SportoPrograma");
        }
    }
}
