using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookService.Data
{
    public class BookDbContextFactory : IDesignTimeDbContextFactory<BookDbContext>
    {
        public BookDbContext CreateDbContext(string[] args)
        {
            return new BookDbContext(new DbContextOptionsBuilder<BookDbContext>().UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=bookDbDev;").Options);
        }
    }
}
