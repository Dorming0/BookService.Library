using BookService.Core.Books;
using BookService.Core.Genres;

namespace BookService.Core.GenreBook
{
    public class GenreBooks
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}
