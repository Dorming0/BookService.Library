using BookService.Core.Genres.Abstractions;
using ServiceExtender.Data;
using ServiceExtender.Data.Services;
using ServiceExtender.Logging;

namespace BookService.Core.Genres
{
    public class DefaultGenreService : GenericService<Genre>, IGenreService
    {
        private readonly IRepository<Genre> _genreRepository;
        public DefaultGenreService(ILoggerService loggerService, IRepository<Genre> genreRepository) : base(loggerService, genreRepository)
        {
            _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
        }
        public Genre Registration(Genre genre)
        {
            if (genre == null)
                throw new ArgumentNullException(nameof(genre));
            if (_genreRepository.Any(x => x.Name == genre.Name))
                throw new InvalidOperationException($"genre name - {genre.Name} is exist");

            genre.Id = (int)_genreRepository.Add(genre);

            return genre;
        }
        public Genre Update(Genre genre)
        {
            if (genre == null)
                throw new ArgumentNullException(nameof(genre));
            if (_genreRepository.Any(x => x.Name == genre.Name && x.Id != genre.Id))
                throw new InvalidOperationException($"genre name - {genre.Name} is exist");

            _genreRepository.Edit(genre);
            return genre;
        }
        public void Delete(int genreId)
        {
            if (!_genreRepository.Any(x => x.Id == genreId))
                throw new ArgumentNullException("GenreId", $"parameter genreId - {genreId} - is not defined");

            _genreRepository.Remove(genreId);
        }

        public async Task ChangeStatus(int genreId)
        {
            var genre = await _genreRepository.FindAsync(genreId);
            if(genre == null)
            {
                throw new ArgumentNullException(nameof(genre));
            }
            if (genre.Status == GenreStatus.Inactive)
            {
                genre.Status = GenreStatus.Active;
            }
            else
            {

                genre.Status = GenreStatus.Inactive;
            }
            await _genreRepository.EditAsync(genre);

        }
    }
}
