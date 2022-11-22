using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.DbOperations;
using WebApi.Entities;
using Xunit;

namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTests :IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
       public void  WhenGivenGenreIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
       {
        UpdateGenreCommand command = new UpdateGenreCommand(_context);
        command.GenreId=0;

        FluentActions.Invoking(()=> command.Handle())
        .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü bulunamadı!");
       }
       [Fact]
       public void  WhenGivenGenreNameInDB_InvalidOperationException_ShouldBeReturn()
       {
        var genres = new Genre(){Name="Deneme"};
        _context.Genres.Add(genres);
        _context.SaveChanges();

        UpdateGenreCommand command = new UpdateGenreCommand(_context);
        command.GenreId = 1;
        command.Model = new UpdateGenreModel(){Name="Deneme"};

        FluentActions.Invoking(()=>command.Handle())
        .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aynı isimli kitap türü zaten mevcut");
       }
        [Fact]
       public void  WhenGivenGenreIdInDb_Genre_ShouldBeUpdate()
       {
        UpdateGenreCommand command = new UpdateGenreCommand(_context);
        UpdateGenreModel model = new UpdateGenreModel(){Name="WhenGivenGenreIdInDb_Genre_ShouldBeUpdate"};
        command.Model = model;
        command.GenreId = 2;
        
        FluentActions.Invoking(()=>command.Handle()).Invoke();
        var genre = _context.Genres.SingleOrDefault(genre => genre.Id == command.GenreId);
        genre.Should().NotBeNull();
        genre.Name.Should().Be(model.Name);
       }
    }
}