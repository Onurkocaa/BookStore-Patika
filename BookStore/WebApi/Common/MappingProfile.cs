using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.BookOperations.Queries.GetBooksDetail;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.UserOperations.Commands.CreateUser;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace WebApi.Common
{
  public class MappingProfile : Profile
  {
      public MappingProfile()
      {
        CreateMap<CreateBookModel, Book>();
        CreateMap<Book,BookDetailViewModel>().ForMember(dest=> dest.Genre, opt=> opt.MapFrom(src=>src.Genre.Name));
        CreateMap<Book,BooksViewModel>().ForMember(dest=> dest.Genre, opt=> opt.MapFrom(src=>src.Genre.Name));
        CreateMap<Genre, GenresViewModel>();
        CreateMap<Genre, GenreDetailViewModel>();
        CreateMap<Author, AuthorsViewModel>();
        CreateMap<Author, AuthorDetailViewModel>().ForMember(dest => dest.Book , opt=> opt.MapFrom(src => src.Book.Title));
        CreateMap<CreateAuthorModel, Author>();
        CreateMap<CreateUserModel, User>();
      }
  }
}