using BookService.Core.Authors;
using BookService.Data.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<GenreModel> Genres { get; set; }
        public DbSet<GenreBookModel> GenreBooks { get; set; }


    }
}
