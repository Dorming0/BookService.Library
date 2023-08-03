using ServiceExtender.Data;

namespace BookService.Core.Books.Abstractions
{
    public interface IBookService : IGenericService<Book>
    {
        Book Registration(Book book);
        Book Update(Book book);
        Task BindGenreAsync(int bookId, int genreId);
        Task UntieGenreAsync(int bookId, int genreId);
        Task ChangeStatus(int bookId);
        void Delete( int bookId);

       
    }
}
