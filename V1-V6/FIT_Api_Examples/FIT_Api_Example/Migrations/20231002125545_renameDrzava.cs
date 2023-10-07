using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Example.Migrations
{
    public partial class renameDrzava : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Drzava",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "skracenica",
                table: "Drzava",
                newName: "skracenicaDrzave");

            migrationBuilder.RenameColumn(
                name: "naziv",
                table: "Drzava",
                newName: "nazivDrzave");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Drzava",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "skracenicaDrzave",
                table: "Drzava",
                newName: "skracenica");

            migrationBuilder.RenameColumn(
                name: "nazivDrzave",
                table: "Drzava",
                newName: "naziv");
        }
    }
}
