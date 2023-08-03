using BookService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookService.Data
{
    public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            return new UserDbContext(new DbContextOptionsBuilder<UserDbContext>().UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=userDbDev;").Options);
        }
    }
}
