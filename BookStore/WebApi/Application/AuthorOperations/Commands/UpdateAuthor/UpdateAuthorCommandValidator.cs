using FluentValidation;
using System;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator :  AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
        RuleFor(command => command.Model.Name).MinimumLength(3).When(x=>x.Model.Name != string.Empty);
        RuleFor(command => command.Model.SurName).MinimumLength(3).When(x=>x.Model.SurName != string.Empty);
        }
    }
}