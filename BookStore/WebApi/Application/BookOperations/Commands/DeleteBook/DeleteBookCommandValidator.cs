using FluentValidation;
using System;

namespace WebApi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidator :  AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
          RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}