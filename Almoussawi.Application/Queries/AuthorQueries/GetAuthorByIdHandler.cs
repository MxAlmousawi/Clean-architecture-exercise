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
    public record GetAuthorByIdQuery(Guid authorId) : IRequest<Response<AuthorDto>>;
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, Response<AuthorDto>>
    {
        private readonly IAuthorRepository authorRepository;

        public GetAuthorByIdHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<Response<AuthorDto>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await authorRepository.GetById(request.authorId);
            return author.Adapt<Response<AuthorDto>>();
        }
    }
}
