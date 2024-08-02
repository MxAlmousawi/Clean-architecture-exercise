using Almoussawi.Domain.Models;
using Almoussawi.Shared;
using Mapster;
using MediatR;
using WebApiExercise.Models.DTO.Author;
using WebApiExercise.Repository.Interfaces;

namespace Almoussawi.Application.Commands.AuthorCommands
{
    public record AddAuthorCommand(AddAuthorDto authorDto):IRequest<Response<AuthorDto>>;
    public class AddAuthorHandler:IRequestHandler<AddAuthorCommand , Response<AuthorDto>>
    {
        private readonly IAuthorRepository authorRepository;

        public AddAuthorHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<Response<AuthorDto>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await authorRepository.Add(request.authorDto);
            return author.Adapt<Response<AuthorDto>>();
        }
    }
}
