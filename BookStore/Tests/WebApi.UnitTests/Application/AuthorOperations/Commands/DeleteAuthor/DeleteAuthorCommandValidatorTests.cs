using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using Xunit;

namespace Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
     public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int authorıd)
     {
        DeleteAuthorCommand command = new DeleteAuthorCommand(null);
        command.AuthorId=authorıd;

        DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
        var result = validator.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);
     }
     [Theory]
     [InlineData(1)]
     [InlineData(2)]
     [InlineData(3)]
     public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int authorıd)
     {
        DeleteAuthorCommand command = new DeleteAuthorCommand(null);
        command.AuthorId=authorıd;

        DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
        var result = validator.Validate(command);

        result.Errors.Count.Should().Be(0);
     }
    }
}