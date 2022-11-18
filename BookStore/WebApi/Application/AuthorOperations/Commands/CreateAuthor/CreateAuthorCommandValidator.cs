using FluentValidation;
using System;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
       public CreateAuthorCommandValidator()
       {
        RuleFor(command => command.Model.BookId).GreaterThan(0);
        RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
        RuleFor(command => command.Model.SurName).NotEmpty().MinimumLength(3);
        RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
       }
    }
}