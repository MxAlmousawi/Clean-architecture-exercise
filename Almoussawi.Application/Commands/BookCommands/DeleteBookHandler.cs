using Almoussawi.Domain.Models;
using Almoussawi.Shared;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiExercise.Models.DTO.Book;
using WebApiExercise.Repository.Interfaces;

namespace Almoussawi.Application.Commands.BookCommands
{
    public record DeleteBookCommand(Guid bookId) : IRequest<Response<BookDto>>;
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, Response<BookDto>>
    {
        private readonly IBookRepository bookRepository;

        public DeleteBookHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<Response<BookDto>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await bookRepository.Delete(request.bookId);
            return book.Adapt<Response<BookDto>>();
        }
    }
}
