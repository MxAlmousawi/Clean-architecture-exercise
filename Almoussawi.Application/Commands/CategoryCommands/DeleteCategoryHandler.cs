using Almoussawi.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repository.Interfaces;

namespace Almoussawi.Application.Commands.CategoryCommands
{
    public record DeleteCategoryCommand(string category) : IRequest<Category?>;
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Category?>
    {
        private readonly ICategoryRepository categoryRepository;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Category?> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await categoryRepository.Delete(request.category);
        }
    }
}
