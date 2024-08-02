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
    public record UpdateAuthorCommand(Guid authorId , UpdateAuthorDto authorDto) : IRequest<Response<AuthorDto>>;
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, Response<AuthorDto>>
    {
        private readonly IAuthorRepository authorRepository;

        public UpdateAuthorHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<Response<AuthorDto>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await authorRepository.Update(request.authorId , request.authorDto);
            return author.Adapt<Response<AuthorDto>>();
        }
    }
}
