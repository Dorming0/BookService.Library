using BookService.Core.Authors;
using BookService.Core.Books;

namespace BookService.Core.Genres
{
    public class Genre
    {
        private List<Author> _authors = new List<Author>();
        private List<Book> _books = new List<Book>();
        public IEnumerable<Book> Books 
        { 
            get
            { 
               foreach(var book in _books)
                {
                    yield return book;
                }
            }
            internal set
            {
                if(_books != null)
                {
                    _books = value.ToList();
                }
            }
        }

        public IEnumerable<Author> Authors
        {
            get
            {
                foreach (var author in _authors)
                {
                    yield return author;
                }
            }
            internal set
            {
                if (_authors != null)
                {
                    _authors = value.ToList();
                }
            }
        }

        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public GenreStatus Status { get; internal set; }

        public Genre() { }
        public Genre(string name, string description, int id = 0)
        {
            Id = id;
            Name = name;
            Description = description;
            Status = new GenreStatus();
        }
    }
}
