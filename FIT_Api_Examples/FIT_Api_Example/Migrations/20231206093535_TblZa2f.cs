using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Example.Migrations
{
    public partial class TblZa2f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Is2FActive",
                table: "KorisnickiNalog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Is2FOtkljucano",
                table: "AutentifikacijaToken",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TwoFKey",
                table: "AutentifikacijaToken",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Is2FActive",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Is2FOtkljucano",
                table: "AutentifikacijaToken");

            migrationBuilder.DropColumn(
                name: "TwoFKey",
                table: "AutentifikacijaToken");
        }
    }
}
