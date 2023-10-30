using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class twoFactorCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "twoFactorCode",
                table: "AutentifikacijaToken",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "twoFactorCodeJelAktiviran",
                table: "AutentifikacijaToken",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "twoFactorCode",
                table: "AutentifikacijaToken");

            migrationBuilder.DropColumn(
                name: "twoFactorCodeJelAktiviran",
                table: "AutentifikacijaToken");
        }
    }
}
