using Almoussawi.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoussawi.Domain.Validations
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.Id).NotEmpty().MaximumLength(20).WithMessage("Category can't be empty and must be less than 20 characters ");
        }
    }
}
