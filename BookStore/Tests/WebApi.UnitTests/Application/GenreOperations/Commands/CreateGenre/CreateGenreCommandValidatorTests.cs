
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using Xunit;

namespace Application.GenreOperations.Commands.CreateGenre
{
public class CreateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
{
[Theory]
[InlineData("")]
[InlineData(" ")]
[InlineData("den")]
[InlineData("de")]
[InlineData("d")]
[InlineData("d ")]
[InlineData("d e")]
public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
{
   CreateGenreCommand command = new CreateGenreCommand(null);
   command.Model= new CreateGenreModel(){Name=name};

   CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
   var result = validator.Validate(command);

   result.Errors.Count.Should().BeGreaterThan(0);
}
[Theory]
[InlineData("dene")]
[InlineData("de n")]
[InlineData("d e n")]
[InlineData("de ne")]
public void WhenInvalidInputsAreGiven_Validator_ShouldNotBeReturnErrors(string name)
{
 CreateGenreCommand command = new CreateGenreCommand(null);
 command.Model = new CreateGenreModel(){Name = name};

 CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
 var result = validator.Validate(command);

 result.Errors.Count.Should().Be(0);
}
}
}