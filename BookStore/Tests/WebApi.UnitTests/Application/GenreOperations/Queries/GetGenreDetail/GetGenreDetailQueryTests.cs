using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.DbOperations;
using Xunit;

namespace Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryTests :IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
       public void WhenGivenGenreIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
       {
        GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
        query.GenreId=0;

        FluentActions.Invoking(()=>query.Handle())
        .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü bulunamadı!");
       }
       [Fact]
       public void WhenGivenGenreIdInDB_Genre_ShouldBeReturn()
       {
        GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
        query.GenreId=1;
        
        FluentActions.Invoking(()=>query.Handle()).Invoke();
        var genre = _context.Genres.SingleOrDefault(genre => genre.Id == query.GenreId);
        genre.Should().NotBeNull();
       }
    }
}