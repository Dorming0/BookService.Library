using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.Data.Migrations
{
    public partial class untie_genre_from_book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GenreBooks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "GenreBooks");
        }
    }
}
