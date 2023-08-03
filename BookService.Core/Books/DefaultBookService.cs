using BookService.Core.Books.Abstractions;
using BookService.Core.GenreBook;
using BookService.Core.Genres;
using ServiceExtender.Data;
using ServiceExtender.Data.Services;
using ServiceExtender.Logging;
using System.Reflection.Metadata.Ecma335;

namespace BookService.Core.Books
{
    public class DefaultBookService : GenericService<Book>, IBookService
    {
        private IRepository<Book> _bookRepository;
        private IRepository<Genre> _genreRepository;
        private IRepository<GenreBooks> _genreBooksRepository;
        public DefaultBookService(ILoggerService loggerService, IRepository<Book> bookRepository, IRepository<Genre> genreRepository, IRepository<GenreBooks> genreBooksRepository)
            : base(loggerService, bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
            _genreBooksRepository = genreBooksRepository ?? throw new ArgumentNullException(nameof(genreBooksRepository));
        }
        public Book Registration(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (_bookRepository.Any(x => x.Name == book.Name))
                throw new InvalidOperationException($"book name-{book.Name}is exist");

            book.Id = (int)_bookRepository.Add(book);
            return book;
        }
        public Book Update(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (_bookRepository.Any(x => x.Name == book.Name && x.Id != book.Id))
                throw new InvalidOperationException($"book name-{book.Name}is exist");

            _bookRepository.Edit(book);
            return book;
        }
        public void Delete(int bookId)
        {
            if (!_bookRepository.Any(x => x.Id == bookId))
                throw new ArgumentNullException("BookId", $"parameter genreId - {bookId} - is not defined");
            _bookRepository.Remove(bookId);
        }

        public async Task BindGenreAsync(int bookId, int genreId)
        {
            var book = await _bookRepository.FindAsync(bookId);
            if (book == null)
            {
                throw new InvalidOperationException(nameof(book));
            }
            if (book.Genres.Any(x => x.Id == genreId))
            {
                return;
            }
            var genre = await _genreRepository.FindAsync(genreId);
            if (genre == null)
            {
                throw new ArgumentNullException(nameof(genre));
            }

            var gb = new GenreBooks
            {
                Genre = genre,
                Book = book
            };
            await _genreBooksRepository.AddAsync(gb);

        }

        public async Task UntieGenreAsync(int bookId, int genreId)
        {
          var book = await _bookRepository.FindAsync(bookId);
            if(book == null) { throw new ArgumentNullException(nameof(book)); }
            if(book.Genres.Any(x =>x.Id == genreId))
            {
                var genreBook = await _genreBooksRepository.FirstOrDefaultAsync(x =>x.Book.Id == bookId && x.Genre.Id == genreId);
                if (genreBook == null)
                {
                    throw new ArgumentNullException(nameof(genreBook)); 
                }
                await _genreBooksRepository.RemoveAsync(genreBook.Id); 
            }
        }
        public async Task ChangeStatus(int bookId)
        {
            var book = await _bookRepository.FindAsync(bookId);
            if (book == null) { throw new ArgumentNullException(nameof(book)); }
            if (book.Status == BookStatus.Active)
            {
                book.Status = BookStatus.Inactive;
            }
            else { book.Status = BookStatus.Active; }
            await _bookRepository.EditAsync(book);
        }
    }
}
