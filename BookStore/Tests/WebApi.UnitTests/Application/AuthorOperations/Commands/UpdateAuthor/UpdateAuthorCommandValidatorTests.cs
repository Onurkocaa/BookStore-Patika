using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using Xunit;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("a","b")]
        [InlineData("","b")]
        [InlineData("as","ba")]
        [InlineData("a","bxx")]
        [InlineData("axx","b")]
        [InlineData("as","")]
        [InlineData("","ba")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name,string surname)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.Model=new UpdateAuthorModel(){Name=name,SurName=surname};

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData("Deneme","Deneme")]
        [InlineData("XXX","SSS")]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(string name,string surname)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.Model=new UpdateAuthorModel(){Name=name,SurName=surname};

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }

    }
}