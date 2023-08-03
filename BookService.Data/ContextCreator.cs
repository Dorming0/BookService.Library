using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using ServiceExtender.Data;

namespace BookService.Data
{
    public class ContextCreator : IContextCreator
    {
        private readonly IMapper _mapper;
        public IMapper Mapper => _mapper;

        public ContextCreator()
        {
            _mapper = new MapperConfiguration(options =>
            {
                options.AddProfile(new MappingProfile());
                options.AddExpressionMapping();
            }).CreateMapper();
        }

        public DbContext Create(bool useLazyLoading = true)
        {
            var builder = new DbContextOptionsBuilder<BookDbContext>().UseNpgsql(ConectionsStrings.NpgSql);
            if (useLazyLoading)
                builder.UseLazyLoadingProxies(true);
            return new BookDbContext(builder.Options);
        }
    }
}
