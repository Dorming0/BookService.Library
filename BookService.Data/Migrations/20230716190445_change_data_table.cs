using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.Data.Migrations
{
    public partial class change_data_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorModelGenreModel");

            migrationBuilder.DropTable(
                name: "BookModelGenreModel");

            migrationBuilder.CreateTable(
                name: "GenreBooks",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreBooks", x => new { x.GenreId, x.BookId });
                    table.ForeignKey(
                        name: "FK_GenreBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreBooks_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreBooks_BookId",
                table: "GenreBooks",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreBooks");

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

            migrationBuilder.CreateTable(
                name: "BookModelGenreModel",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "integer", nullable: false),
                    GenresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookModelGenreModel", x => new { x.BooksId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_BookModelGenreModel_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookModelGenreModel_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorModelGenreModel_GenresId",
                table: "AuthorModelGenreModel",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_BookModelGenreModel_GenresId",
                table: "BookModelGenreModel",
                column: "GenresId");
        }
    }
}
