using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiExercise.Models.DTO.Author;
using WebApiExercise.Models.DTO.Book;
using WebApiExercise.Repository.Interfaces;
using MediatR;
using Almoussawi.Application.Commands.AuthorCommands;
using Almoussawi.Application.Queries.AuthorQueries;
namespace Almoussawi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : HandleResults
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new GetAllAuthorsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return HandleResult(await Mediator.Send(new GetAuthorByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddAuthorDto authorDto)
        {
            return HandleResult(await Mediator.Send(new AddAuthorCommand(authorDto)));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAuthorDto authorDto)
        {
            return HandleResult(await Mediator.Send(new UpdateAuthorCommand(id , authorDto)));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteAuthorCommand(id)));
        }

    }
}
