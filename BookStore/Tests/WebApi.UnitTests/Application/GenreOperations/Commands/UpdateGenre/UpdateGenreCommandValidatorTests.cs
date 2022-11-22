using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using Xunit;

namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests :IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("  ")]
        [InlineData("de")]
        [InlineData("d")]
        [InlineData("den")]
       public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string genreName)
       {
         UpdateGenreCommand command = new UpdateGenreCommand(null);
         command.Model=new UpdateGenreModel(){Name=genreName};

         UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
         var result = validator.Validate(command);

         result.Errors.Count.Should().BeGreaterThan(0);
       } 
       [Theory]
        [InlineData("dene")]
        [InlineData("lor d")]
        [InlineData("dene m ")]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(string genreName)
       {
         UpdateGenreCommand command = new UpdateGenreCommand(null);
         command.Model=new UpdateGenreModel(){Name=genreName};

         UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
         var result = validator.Validate(command);

         result.Errors.Count.Should().Be(0);
       } 
    }
}