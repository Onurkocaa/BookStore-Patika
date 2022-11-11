using FluentValidation;
using System;
namespace WebApi.BookOperations.GetBooksDetail
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
         RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}