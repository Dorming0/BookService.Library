using BookService.Core.Authors.Abstractions;
using BookService.Core.Genres;
using ServiceExtender.Data;
using ServiceExtender.Data.Services;
using ServiceExtender.Logging;

namespace BookService.Core.Authors
{
    public class DefaultAuthorService : GenericService<Author>, IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<Genre> _genreRepository;
        public DefaultAuthorService(ILoggerService loggerService, IRepository<Author> authorRepository, IRepository<Genre> genreRepository)
            : base(loggerService, authorRepository)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
        }

        public  async Task BindGenreAsync(int authorId, int genreId)
        {
            var author = await _authorRepository.FindAsync(authorId);
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }
            if(author.Genres.Any(x=>x.Id == genreId))
            {
                return;
            }
            var genre = await _genreRepository.FindAsync(genreId);
            if (genre == null)
            {
                throw new ArgumentNullException(nameof(genre));
            }
            author.AddGenre(genre);
            await _authorRepository.EditAsync(author);
        }

        public async Task ChangeStatus(int authorId)
        {
            var author = await _authorRepository.FindAsync(authorId);
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }
            if(author.Status == AuthorStatus.Inactive)
            {
               author.Status = AuthorStatus.Active;
            }
            else
            {
                author.Status = AuthorStatus.Inactive;
            }
            await _authorRepository.EditAsync(author);
           
        }

        public void Delite(int authorId)
        {
            if (!_authorRepository.Any(x => x.Id == authorId))
                throw new ArgumentNullException("AuthorId", $"parameter authorId - {authorId} - is not defined");
            _authorRepository.Remove(authorId);
        }

        public Author Registration(Author author)
        {
            if (author == null) throw new ArgumentNullException(nameof(author));
            if (_authorRepository.Any(x => x.Name == author.Name))
                throw new InvalidOperationException($"author name-{author.Name}is exist");
            author.Id = (int)_authorRepository.Add(author);
            return author;
        }

        public async Task UntieGenreAsync(int authorId, int genreId)
        {
            var author = await _authorRepository.FindAsync(authorId);
            if(author == null)
              throw new ArgumentNullException(nameof(author));
            if(author.Genres.Any(x=> x.Id == genreId))
            {
                author.UntieGenre(genreId);
               await _authorRepository.EditAsync(author);
            }
        }

        public Author Update(Author author)
        {
            if (author == null) throw new ArgumentNullException(nameof(author));
            if (_authorRepository.Any(x => x.Name == author.Name && x.Id != author.Id)) throw new InvalidOperationException($"author name-{author.Name}is exist");
            _authorRepository.Edit(author);
            return author;
        }
        
        
    }
}
