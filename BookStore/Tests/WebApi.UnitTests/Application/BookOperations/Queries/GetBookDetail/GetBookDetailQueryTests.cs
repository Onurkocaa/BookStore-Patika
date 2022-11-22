using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Queries.GetBooksDetail;
using WebApi.DbOperations;
using Xunit;

namespace Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQueryTests :IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
       public  GetBookDetailQueryTests(CommonTestFixture testFixture)
       {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
       }
       [Fact]
       public void WhenGivenBookIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
       {
        GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
        query.BookId=0;

        FluentActions.Invoking(()=>query.Handle())
        .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Bulunamadı.");
       }
        [Fact]
       public void WhenValidInputBookIdGiven_Book_GetDetail()
       {
        GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
        query.BookId = 2;

        FluentActions.Invoking(()=>query.Handle()).Invoke();
        var book = _context.Books.SingleOrDefault(book=>book.Id==query.BookId);
        book.Should().NotBeNull();
       }
    }
}