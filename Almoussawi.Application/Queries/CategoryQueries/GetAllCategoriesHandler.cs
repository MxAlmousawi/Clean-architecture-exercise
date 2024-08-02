using Almoussawi.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repository.Interfaces;
using WebApiExercise.Models.DTO.Book;
using WebApiExercise.Repository.Interfaces;

namespace Almoussawi.Application.Queries.CategoriesQueries
{
    public record GetAllCategoriesQuery:IRequest<List<Category>>;

    public class GetAllCategoriesHandler:IRequestHandler<GetAllCategoriesQuery , List<Category>>
    {
        private readonly ICategoryRepository categoryRepository;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await categoryRepository.GetAll();
        }
    }
}
