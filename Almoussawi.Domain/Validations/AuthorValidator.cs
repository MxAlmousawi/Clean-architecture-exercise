using Almoussawi.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoussawi.Domain.Validations
{
    public class AuthorValidator:AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(author => author.Name)
                .NotEmpty().WithMessage("Name can't be empty")
                .Length(1,50).WithMessage("Name must be less than 51 characters");
        }
    }
}
