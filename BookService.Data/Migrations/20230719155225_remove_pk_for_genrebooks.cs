using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BookService.Data.Migrations
{
    public partial class remove_pk_for_genrebooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreBooks",
                table: "GenreBooks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "GenreBooks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreBooks",
                table: "GenreBooks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GenreBooks_GenreId",
                table: "GenreBooks",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreBooks",
                table: "GenreBooks");

            migrationBuilder.DropIndex(
                name: "IX_GenreBooks_GenreId",
                table: "GenreBooks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "GenreBooks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreBooks",
                table: "GenreBooks",
                columns: new[] { "GenreId", "BookId" });
        }
    }
}
