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
    public record UpdateBookCommand(Guid bookId, UpdateBookDto bookDto) : IRequest<Response<BookDto>>;
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, Response<BookDto>>
    {
        private readonly IBookRepository bookRepository;

        public UpdateBookHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<Response<BookDto>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await bookRepository.Update( request.bookId ,request.bookDto);
            return book.Adapt<Response<BookDto>>();
        }
    }
}
