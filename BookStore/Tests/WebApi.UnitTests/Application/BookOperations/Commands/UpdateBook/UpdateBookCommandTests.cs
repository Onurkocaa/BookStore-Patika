using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DbOperations;
using Xunit;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTests:IClassFixture<CommonTestFixture>
    {
       private readonly BookStoreDbContext _context; 
       public UpdateBookCommandTests(CommonTestFixture testFixture)
       {
        _context = testFixture.Context;
       }
       [Fact]
       public void  WhenGivenBookIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
       {
        UpdateBookCommand command = new UpdateBookCommand(_context);
        command.BookId = 0;
        
        FluentActions.Invoking(()=>command.Handle())
        .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek Kitap Bulunamadı!");
       }
        [Fact]
       public void  WhenGivenBookIdInDb_Book_ShouldBeUpdate()
       {
        UpdateBookCommand command = new UpdateBookCommand(_context);
        UpdateBookModel model = new UpdateBookModel(){Title="WhenGivenBookIdInDb_Book_ShouldBeUpdate",GenreId=1};
        command.Model =model;
        command.BookId=2;

        FluentActions.Invoking(()=>command.Handle()).Invoke();
        var book = _context.Books.SingleOrDefault(book=>book.Id == command.BookId);
        book.Should().NotBeNull();
        book.GenreId.Should().Be(model.GenreId);
        book.Title.Should().Be(model.Title);
       }
    }
}