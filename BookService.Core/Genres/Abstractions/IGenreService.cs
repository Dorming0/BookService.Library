using ServiceExtender.Data;

namespace BookService.Core.Genres.Abstractions
{
    public interface IGenreService : IGenericService<Genre>
    {
        Genre Registration(Genre genre);
        Genre Update(Genre genre);
        Task ChangeStatus(int genreId);
        void Delete(int genreId);

    }
}
