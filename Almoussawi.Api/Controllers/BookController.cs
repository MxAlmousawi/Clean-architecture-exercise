using Almoussawi.Application.Commands.BookCommands;
using Almoussawi.Application.Queries.AuthorQueries;
using Almoussawi.Application.Queries.BookQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiExercise.Models.DTO.Book;
using WebApiExercise.Repository.Interfaces;

namespace Almoussawi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : HandleResults
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new GetAllBooksQuery()));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return HandleResult(await Mediator.Send(new GetBookByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddBookDto bookDto)
        {
            return HandleResult(await Mediator.Send(new AddBookCommand(bookDto)));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBookDto bookDto)
        {
            return HandleResult(await Mediator.Send(new UpdateBookCommand(id , bookDto)));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteBookCommand(id)));
        }

    }
}
