using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaFinalMVC.Data.Migrations
{
    public partial class movieCelebrity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieCelebrity",
                columns: table => new
                {
                    MovieCelebrityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CelebrityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCelebrity", x => x.MovieCelebrityId);
                    table.ForeignKey(
                        name: "FK_MovieCelebrity_Celebrity_CelebrityId",
                        column: x => x.CelebrityId,
                        principalTable: "Celebrity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCelebrity_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCelebrity_CelebrityId",
                table: "MovieCelebrity",
                column: "CelebrityId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCelebrity_MovieId",
                table: "MovieCelebrity",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCelebrity");
        }
    }
}
