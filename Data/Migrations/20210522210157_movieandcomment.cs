using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaFinalMVC.Data.Migrations
{
    public partial class movieandcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celebrity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celebrity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Celebrity_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CelebrityProfession",
                columns: table => new
                {
                    CelebrityProfessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CelebrityId = table.Column<int>(type: "int", nullable: false),
                    ProfessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelebrityProfession", x => x.CelebrityProfessionId);
                    table.ForeignKey(
                        name: "FK_CelebrityProfession_Celebrity_CelebrityId",
                        column: x => x.CelebrityId,
                        principalTable: "Celebrity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CelebrityProfession_Profession_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Profession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Celebrity_CountryId",
                table: "Celebrity",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CelebrityProfession_CelebrityId",
                table: "CelebrityProfession",
                column: "CelebrityId");

            migrationBuilder.CreateIndex(
                name: "IX_CelebrityProfession_ProfessionId",
                table: "CelebrityProfession",
                column: "ProfessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelebrityProfession");

            migrationBuilder.DropTable(
                name: "Celebrity");

            migrationBuilder.DropTable(
                name: "Profession");
        }
    }
}
