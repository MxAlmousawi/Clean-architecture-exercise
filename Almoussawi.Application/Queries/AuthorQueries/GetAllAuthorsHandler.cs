using Almoussawi.Domain.Models;
using Almoussawi.Shared;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiExercise.Models.DTO.Author;
using WebApiExercise.Repository.Interfaces;

namespace Almoussawi.Application.Queries.AuthorQueries
{
    public record GetAllAuthorsQuery:IRequest<Response<List<AuthorDto>>>;
    public class GetAllAuthorsHandler:IRequestHandler<GetAllAuthorsQuery , Response<List<AuthorDto>>>
    {
        private readonly IAuthorRepository authorRepository;

        public GetAllAuthorsHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<Response<List<AuthorDto>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await authorRepository.GetAll();
            return authors.Adapt<Response<List<AuthorDto>>>();
        }
    }
}
