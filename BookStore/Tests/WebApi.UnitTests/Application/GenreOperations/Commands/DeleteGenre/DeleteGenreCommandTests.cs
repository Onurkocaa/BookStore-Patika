using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.DbOperations;
using Xunit;

namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenGivenGenreIdIsNotinDb_InvalidOperationException_ShouldBeReturn()
        {
           DeleteGenreCommand command = new DeleteGenreCommand(_context);
           command.GenreId=0;

           FluentActions.Invoking(()=>command.Handle())
           .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü bulunamadı"); 
        }
         [Fact]
          public void WhenGivenBookIdInDb_Genre_ShouldBeRemove()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId=1;
            FluentActions.Invoking(()=>command.Handle()).Invoke();
            var genre = _context.Genres.SingleOrDefault(genre=>genre.Id==command.GenreId);
            genre.Should().Be(null);
        }
    }
}