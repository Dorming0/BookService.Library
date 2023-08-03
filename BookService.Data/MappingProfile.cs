using AutoMapper;
using BookService.Core.Authors;
using BookService.Core.Books;
using BookService.Core.GenreBook;
using BookService.Core.Genres;
using BookService.Data.EF.Models;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace BookService.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorModel>()
                .ForMember(desc => desc.Id, x => x.MapFrom(x => x.Id))
                .ForMember(desc => desc.Name, x => x.MapFrom(x => x.Name))
                .ForMember(desc => desc.Surname, x => x.MapFrom(x => x.Surname))
                .ForMember(desc => desc.Description, x => x.MapFrom(x => x.Description))
                .ForMember(desc => desc.Status, x => x.MapFrom(x => (BookStatus)x.Status))
                .ForMember(desc => desc.Books, x => x.Ignore());


            CreateMap<AuthorModel, Author>()
                .ForMember(desc => desc.Id, x => x.MapFrom(x => x.Id))
                .ForMember(desc => desc.Name, x => x.MapFrom(x => x.Name))
                .ForMember(desc => desc.Surname, x => x.MapFrom(x => x.Surname))
                .ForMember(desc => desc.Description, x => x.MapFrom(x => x.Description))
                .ForMember(desc => desc.Status, x => x.MapFrom(x => (BookStatus)x.Status))
                .ForMember(desc => desc.Books, x => x.MapFrom(x => x.Books))
                .ForMember(desc => desc.Genres, x => x.
                    MapFrom(x => x.Books.SelectMany(x => x.GenreBooks).Select(x => x.Genre).GroupBy(x => x.Name).Select(x => x.First())));
                

            CreateMap<BookModel, Book>()
                .ForMember(desc => desc.Author, x => x.MapFrom(x => x.Author))
                .ForMember(desc => desc.Genres, x => x.MapFrom(x => x.GenreBooks.Select(x => x.Genre)));
            CreateMap<Book, BookModel>()
                .ForMember(desc => desc.Author, x => x.Ignore())
                .ForMember(dest => dest.AuthorId, x => x.MapFrom(src => src.Author.Id));

            CreateMap<Genre, GenreModel>()
                .ForMember(desc => desc.GenreBooks, x => x.Ignore())
                .ForMember(dest => dest.Status, x => x.MapFrom(src => (int)src.Status));
               

            CreateMap<GenreModel, Genre>()
                .ForMember(desc => desc.Books, x => x.MapFrom(src => src.GenreBooks.Select(x => x.Book)))
                .ForMember(dest => dest.Status, x => x.MapFrom(src => (GenreStatus)src.Status));

            CreateMap<GenreBooks, GenreBookModel>()
                .ForMember(desc => desc.GenreId, x => x.MapFrom(src => src.Genre.Id))
                .ForMember(desc => desc.BookId, x => x.MapFrom(src => src.Book.Id))
                .ForMember(desc => desc.Book, x => x.Ignore())
                .ForMember(desc => desc.Genre, x => x.Ignore());

            CreateMap<GenreBookModel, GenreBooks>()
                .ForMember(desc => desc.Genre, x => x.MapFrom(src => src.Genre))
                .ForMember (desc => desc.Book, x => x.MapFrom(src => src.Book));





        }

    }
}
