using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Example.Migrations
{
    public partial class addPrijavaIspita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrijavaIspita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPrijave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    IspitID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijavaIspita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrijavaIspita_Ispit_IspitID",
                        column: x => x.IspitID,
                        principalTable: "Ispit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PrijavaIspita_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaIspita_IspitID",
                table: "PrijavaIspita",
                column: "IspitID");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaIspita_StudentID",
                table: "PrijavaIspita",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrijavaIspita");
        }
    }
}
