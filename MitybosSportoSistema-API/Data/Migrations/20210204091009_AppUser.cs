using Microsoft.EntityFrameworkCore.Migrations;

namespace MitybosSportoSistema_API.Data.Migrations
{
    public partial class AppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "Kcal",
                table: "Receptai",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VartotojasId",
                table: "Receptai",
                nullable: true);


            migrationBuilder.AddColumn<int>(
                name: "VartotojasId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vartotojai",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vardas = table.Column<string>(nullable: true),
                    Pavarde = table.Column<string>(nullable: true),
                    Ugis = table.Column<int>(nullable: false),
                    Svoris = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vartotojai", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receptai_VartotojasId",
                table: "Receptai",
                column: "VartotojasId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VartotojasId",
                table: "AspNetUsers",
                column: "VartotojasId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Vartotojai_VartotojasId",
                table: "AspNetUsers",
                column: "VartotojasId",
                principalTable: "Vartotojai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receptai_Vartotojai_VartotojasId",
                table: "Receptai",
                column: "VartotojasId",
                principalTable: "Vartotojai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Vartotojai_VartotojasId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingridientai_Produktai_ProduktasId",
                table: "Ingridientai");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingridientai_Receptai_ReceptasId",
                table: "Ingridientai");

            migrationBuilder.DropForeignKey(
                name: "FK_Receptai_Vartotojai_VartotojasId",
                table: "Receptai");

            migrationBuilder.DropTable(
                name: "Vartotojai");

            migrationBuilder.DropIndex(
                name: "IX_Receptai_VartotojasId",
                table: "Receptai");

            migrationBuilder.DropIndex(
                name: "IX_Ingridientai_ProduktasId",
                table: "Ingridientai");

            migrationBuilder.DropIndex(
                name: "IX_Ingridientai_ReceptasId",
                table: "Ingridientai");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_VartotojasId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Kcal",
                table: "Receptai");

            migrationBuilder.DropColumn(
                name: "VartotojasId",
                table: "Receptai");

            migrationBuilder.DropColumn(
                name: "ProduktasId",
                table: "Ingridientai");

            migrationBuilder.DropColumn(
                name: "ReceptasId",
                table: "Ingridientai");

            migrationBuilder.DropColumn(
                name: "VartotojasId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ReceptasId",
                table: "Produktai",
                type: "int",
                nullable: true);

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
    }
}
