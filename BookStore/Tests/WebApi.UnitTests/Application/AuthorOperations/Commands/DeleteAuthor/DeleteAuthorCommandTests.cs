using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.DbOperations;
using Xunit;

namespace Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenGivenAuthorIdIsNotinDb_InvalidOperationException_ShouldBeReturn()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId=0;
            
            FluentActions.Invoking(()=>command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı!");
        }
         [Fact]
        public void WhenGivenAuthorIdInDb_InvalidOperationException_ShouldBeReturn()
        {
         DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
         command.AuthorId=1;  

         FluentActions.Invoking(()=>command.Handle()).Invoke();
         var author = _context.Authors.SingleOrDefault(author=>author.Id==command.AuthorId);
         author.Should().Be(null); 
        }
    }
}