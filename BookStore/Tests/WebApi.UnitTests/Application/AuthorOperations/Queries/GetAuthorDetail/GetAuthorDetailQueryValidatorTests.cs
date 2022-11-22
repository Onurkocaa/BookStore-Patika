using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using Xunit;

namespace Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
     public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int authorıd)
     {
        GetAuthorDetailQuery query = new GetAuthorDetailQuery(null,null);
        query.AuthorId=authorıd;

        GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
        var result = validator.Validate(query);

        result.Errors.Count.Should().BeGreaterThan(0);
     }
     [Theory]
     [InlineData(1)]
     [InlineData(2)]
     [InlineData(3)]
     public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int authorıd)
     {
        GetAuthorDetailQuery query = new GetAuthorDetailQuery(null,null);
        query.AuthorId=authorıd;

        GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
        var result = validator.Validate(query);

        result.Errors.Count.Should().Be(0);
     }
    }
}