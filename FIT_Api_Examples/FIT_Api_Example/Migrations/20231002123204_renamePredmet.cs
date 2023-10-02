using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Example.Migrations
{
    public partial class renamePredmet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sifra",
                table: "Predmet",
                newName: "sifraPredmeta");

            migrationBuilder.RenameColumn(
                name: "Naziv",
                table: "Predmet",
                newName: "nazivPredmeta");

            migrationBuilder.RenameColumn(
                name: "ECTS",
                table: "Predmet",
                newName: "ectsBodovi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sifraPredmeta",
                table: "Predmet",
                newName: "Sifra");

            migrationBuilder.RenameColumn(
                name: "nazivPredmeta",
                table: "Predmet",
                newName: "Naziv");

            migrationBuilder.RenameColumn(
                name: "ectsBodovi",
                table: "Predmet",
                newName: "ECTS");
        }
    }
}
