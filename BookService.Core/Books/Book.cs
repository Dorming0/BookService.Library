using BookService.Core.Authors;
using BookService.Core.Genres;

namespace BookService.Core.Books
{
    public class Book
    {
        private List<Genre> _genres = new List<Genre>();
        public IEnumerable<Genre> Genres
        {
            get
            {
                foreach (var genre in _genres)
                    yield return genre;
            }
            // если value != null, то используется метод ToList(), если value == null, то используется ?? new List<Genre>()
            internal set => _genres = value?.ToList() ?? new List<Genre>();
        }
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Descriptions { get; internal set; }
        public decimal Price { get; internal set; }
        public BookStatus Status { get; internal set; }
        public Author Author { get; internal set; }

        public Book() { }
        public Book(string name, string description, decimal price, int authorId, int id = 0)
        {
            Name = name;
            Descriptions = description;
            Price = price;
            Author = new Author { Id = authorId } ;
            Status = BookStatus.Inactive;
            Id = id;
        }
        public void AddGenre(Genre genre)
        {
            _genres.Add(genre);
        }
        public void UntieGenre(int genreId)
        {
            _genres.RemoveAll(x => x.Id == genreId);
        }

    }
}
