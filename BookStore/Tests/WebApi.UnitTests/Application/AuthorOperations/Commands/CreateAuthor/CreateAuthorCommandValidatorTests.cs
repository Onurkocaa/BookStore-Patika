using System;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using Xunit;

namespace Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
    [Theory]
    [InlineData("De","xa",0)]
    [InlineData("Dene","x",6)]
    [InlineData("Dene","neme",0)]
    [InlineData("","",0)]
    [InlineData("D","neme",6)]
    [InlineData(" "," ",1)]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name,string surname,int bookıd)
    {
       CreateAuthorCommand command = new CreateAuthorCommand(null,null);
       command.Model= new CreateAuthorModel(){Name=name,SurName=surname,PublishDate=DateTime.Now.Date.AddYears(-1),BookId=bookıd};
       
       CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
       var result = validator.Validate(command);

       result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
    {
        CreateAuthorCommand command = new CreateAuthorCommand(null,null);
        command.Model= new CreateAuthorModel(){Name="Orhan",SurName="Pamuk",PublishDate=DateTime.Now.Date,BookId=1};

        CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
        var result = validator.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
    {
        CreateAuthorCommand command = new CreateAuthorCommand(null,null);
        command.Model= new CreateAuthorModel(){Name="Orhan",SurName="Pamuk",PublishDate=DateTime.Now.Date.AddYears(-3),BookId=1};

        CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
        var result = validator.Validate(command);

        result.Errors.Count.Should().Equals(0);
    }
    }
}