using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaFinalMVC.Data.Migrations
{
    public partial class deleteCountrMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Country_CountryId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_CountryId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Movie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CountryId",
                table: "Movie",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Country_CountryId",
                table: "Movie",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
