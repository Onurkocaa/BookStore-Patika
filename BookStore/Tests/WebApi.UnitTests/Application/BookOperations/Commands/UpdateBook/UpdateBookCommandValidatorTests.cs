using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using Xunit;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
    [Theory]
    [InlineData(1,1,"lor")]
    [InlineData(0,1,"lord")]
    [InlineData(1,0,"lord")]
    [InlineData(0,0,"lor")]
    [InlineData(1,1,"")]
    [InlineData(1,1," ")]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int bookid, int genreid, string title)
    {
        UpdateBookCommand command = new UpdateBookCommand(null);
        command.Model= new UpdateBookModel(){Title=title,GenreId = genreid};
        command.BookId = bookid;

        UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
        var result = validator.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Theory]
    [InlineData(1,1,"Lord Of The Rings")]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int bookid, int genreid, string title)
    {
        UpdateBookCommand command = new UpdateBookCommand(null);
        command.Model= new UpdateBookModel(){Title=title,GenreId = genreid};
        command.BookId = bookid;

        UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
        var result = validator.Validate(command);

        result.Errors.Count.Should().Be(0);
    }
    }
}