using Almoussawi.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoussawi.Domain.Validations
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Title)
                .NotEmpty().WithMessage("Title can't be empty")
                .MaximumLength(50).WithMessage("Title must be less than 51 characters");
        }
    }

}
