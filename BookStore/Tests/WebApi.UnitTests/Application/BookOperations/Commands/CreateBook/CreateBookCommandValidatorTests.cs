using Xunit;
using TestSetup;
using WebApi.Application.BookOperations.Commands.CreateBook;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using FluentAssertions;
using System;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lord Of The Rings",0,0)]
        [InlineData("Lord Of The Rings",0,1)]
        [InlineData("Lord Of The Rings",100,0)]
        [InlineData("",0,0)]
        [InlineData("",100,1)]
        [InlineData("",0,1)]
        [InlineData("Lor",100,1)]
        [InlineData("Lord",100,0)]
        [InlineData("Lord",0,1)]
        [InlineData(" ",100,1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title,int pageCount,int genreId)
        {
            //arrage
          CreateBookCommand command = new CreateBookCommand(null,null);
          command.Model = new CreateBookModel(){
            Title =title,PageCount=pageCount,PublishDate=DateTime.Now.Date.AddYears(-1),GenreId=genreId
          };
          //act
          CreateBookCommandValidator validator = new CreateBookCommandValidator();
          var result =validator.Validate(command);
          //assert
          result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
             CreateBookCommand command = new CreateBookCommand(null,null);
             command.Model = new CreateBookModel(){
            Title = "Lord Of The Rings",
            PageCount= 200,
            PublishDate=DateTime.Now.Date,
            GenreId= 1
          };
          CreateBookCommandValidator validator = new CreateBookCommandValidator();
          var result = validator.Validate(command);
          result.Errors.Count.Should().BeGreaterThan(0);
        }
                [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
             CreateBookCommand command = new CreateBookCommand(null,null);
             command.Model = new CreateBookModel(){
            Title = "Lord Of The Rings",
            PageCount= 200,
            PublishDate=DateTime.Now.Date.AddYears(-2),
            GenreId= 1
          };
          CreateBookCommandValidator validator = new CreateBookCommandValidator();
          var result = validator.Validate(command);
          result.Errors.Count.Should().Equals(0);
        }
    }
}