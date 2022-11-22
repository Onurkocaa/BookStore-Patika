using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.DbOperations;
using Xunit;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenGivenAuthorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId=0;

            FluentActions.Invoking(()=>command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar Bulunamadı!");
        }
        [Fact]
        public void WhenGivenAuthorIdInDB_Author_ShouldBeUpdate()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            UpdateAuthorModel model =new UpdateAuthorModel(){Name="XXXX",SurName="AAAA"};
            command.Model=model;
            command.AuthorId=2; 

            FluentActions.Invoking(()=>command.Handle()).Invoke();
            var author = _context.Authors.SingleOrDefault(author=>author.Id==command.AuthorId);
            author.Should().NotBeNull();
            author.Name.Should().Be(model.Name);
            author.SurName.Should().Be(model.SurName);
        }
    }
}