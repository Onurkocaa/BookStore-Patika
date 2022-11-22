using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Queries.GetBooksDetail;
using Xunit;

namespace Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQueryValidatorTests :IClassFixture<CommonTestFixture>
 {
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int bookId)
    {
       GetBookDetailQuery query = new GetBookDetailQuery(null,null);
       query.BookId=bookId;
       
       GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
       var result = validator.Validate(query);

       result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int bookId)
    {
       GetBookDetailQuery query = new GetBookDetailQuery(null,null);
       query.BookId=bookId;
       
       GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
       var result = validator.Validate(query);

       result.Errors.Count.Should().Be(0);
    }
 }
}