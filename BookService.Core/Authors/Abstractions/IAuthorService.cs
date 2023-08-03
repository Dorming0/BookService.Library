using BookService.Core.Books;
using ServiceExtender.Data;

namespace BookService.Core.Authors.Abstractions
{
    public interface IAuthorService : IGenericService<Author>
    {
        Author Registration(Author author);
        Author Update(Author author);
        Task BindGenreAsync(int authorId, int genreId);
        Task UntieGenreAsync (int authorId, int genreId);
        Task ChangeStatus(int authorId);

        void Delite(int authorId);


    }
}
