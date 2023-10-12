using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Examples.Migrations
{
    /// <inheritdoc />
    public partial class UpisAkGodine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UpisAkGodine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumUpisZimski = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GodinaStudija = table.Column<int>(type: "int", nullable: false),
                    CijenaSkolarine = table.Column<float>(type: "real", nullable: false),
                    JelObnova = table.Column<bool>(type: "bit", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    AkademskaGodinaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpisAkGodine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_AkademskaGodina_AkademskaGodinaID",
                        column: x => x.AkademskaGodinaID,
                        principalTable: "AkademskaGodina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_AkademskaGodinaID",
                table: "UpisAkGodine",
                column: "AkademskaGodinaID");

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_StudentID",
                table: "UpisAkGodine",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpisAkGodine");
        }
    }
}
