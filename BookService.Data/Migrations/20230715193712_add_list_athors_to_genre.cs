using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.Data.Migrations
{
    public partial class add_list_athors_to_genre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Auhtors_AuthorId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_AuthorId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Genres");

            migrationBuilder.CreateTable(
                name: "AuthorModelGenreModel",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "integer", nullable: false),
                    GenresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorModelGenreModel", x => new { x.AuthorsId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_AuthorModelGenreModel_Auhtors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Auhtors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorModelGenreModel_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorModelGenreModel_GenresId",
                table: "AuthorModelGenreModel",
                column: "GenresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorModelGenreModel");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Genres",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_AuthorId",
                table: "Genres",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Auhtors_AuthorId",
                table: "Genres",
                column: "AuthorId",
                principalTable: "Auhtors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
