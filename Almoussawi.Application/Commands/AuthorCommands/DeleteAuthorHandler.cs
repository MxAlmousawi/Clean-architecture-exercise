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

namespace Almoussawi.Application.Commands.AuthorCommands
{
    public record DeleteAuthorCommand(Guid authorId) : IRequest<Response<AuthorDto>>;
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, Response<AuthorDto>>
    {
        private readonly IAuthorRepository authorRepository;

        public DeleteAuthorHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<Response<AuthorDto>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await authorRepository.Delete(request.authorId);
            return author.Adapt<Response<AuthorDto>>();
        }
    }
}
