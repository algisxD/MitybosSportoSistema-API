using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MitybosSportoSistema_API.Data.Migrations
{
    public partial class UsersMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ArViesas",
                table: "Receptai",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ValgiarastisId",
                table: "Receptai",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Valgiarasciai",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pavadinimas = table.Column<string>(nullable: true),
                    SukurimoData = table.Column<DateTime>(nullable: false),
                    SavaitesDiena = table.Column<string>(nullable: true),
                    SavaitesDienosSkaitineReiksme = table.Column<int>(nullable: false),
                    ArAktyvus = table.Column<bool>(nullable: false),
                    VartotojasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valgiarasciai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valgiarasciai_Vartotojai_VartotojasId",
                        column: x => x.VartotojasId,
                        principalTable: "Vartotojai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receptai_ValgiarastisId",
                table: "Receptai",
                column: "ValgiarastisId");

            migrationBuilder.CreateIndex(
                name: "IX_Valgiarasciai_VartotojasId",
                table: "Valgiarasciai",
                column: "VartotojasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receptai_Valgiarasciai_ValgiarastisId",
                table: "Receptai",
                column: "ValgiarastisId",
                principalTable: "Valgiarasciai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receptai_Valgiarasciai_ValgiarastisId",
                table: "Receptai");

            migrationBuilder.DropTable(
                name: "Valgiarasciai");

            migrationBuilder.DropIndex(
                name: "IX_Receptai_ValgiarastisId",
                table: "Receptai");

            migrationBuilder.DropColumn(
                name: "ArViesas",
                table: "Receptai");

            migrationBuilder.DropColumn(
                name: "ValgiarastisId",
                table: "Receptai");
        }
    }
}
