using BookService.Core.Books;
using BookService.Core.Genres;

namespace BookService.Core.Authors
{
    public class Author
    {
        private List<Book> _books = new List<Book>();
        private List<Genre> _genres = new List<Genre>();
        public IEnumerable<Genre> Genres
        {
            get
            {
                foreach (var genre in _genres)
                {
                    yield return genre;
                }
            }
            internal set
            {
                if (value != null)
                {
                    _genres = value.ToList();
                }
            }
        }

        public IEnumerable<Book> Books
        {
            get
            {
                foreach (var book in _books)
                {
                    yield return book;
                }
            }
            internal set
            {
                if (value != null)
                {
                    _books = value.ToList();
                }
            }
        }

        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Surname { get; internal set; }
        public string Description { get; internal set; }
        public AuthorStatus Status { get; internal set; }

        public Author() { }
        public Author(string name, string surname, string description, int id = 0)
        {
            Name = name;
            Surname = surname;
            Description = description;
            Status = AuthorStatus.Inactive;
            Id = id;

        }
        public void AddGenre(Genre genre)
        {
            _genres.Add(genre);
        }
        public void UntieGenre(int genreId)
        {
            _genres.RemoveAll(x=>x.Id == genreId);
        }
    }
}
