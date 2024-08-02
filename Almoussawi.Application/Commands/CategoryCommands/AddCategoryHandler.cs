using Almoussawi.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repository.Interfaces;
using WebApiExercise.Repository.Interfaces;

namespace Almoussawi.Application.Commands.CategoryCommands
{
    public record AddCategoryCommand(string category) : IRequest<Category?>;
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, Category?>
    {
        private readonly ICategoryRepository categoryRepository;

        public AddCategoryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Category?> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            return await categoryRepository.Add(request.category);
        }
    }
}
