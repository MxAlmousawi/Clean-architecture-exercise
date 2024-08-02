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
using WebApiExercise.Models.DTO.Book;
using WebApiExercise.Repository.Interfaces;

namespace Almoussawi.Application.Commands.BookCommands
{
    public record AddBookCommand(AddBookDto bookDto):IRequest<Response<BookDto>>;
    public class AddBookHandler:IRequestHandler<AddBookCommand , Response<BookDto>>
    {
        private readonly IBookRepository bookRepository;

        public AddBookHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<Response<BookDto>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = await bookRepository.Add(request.bookDto);
            return book.Adapt<Response<BookDto>>();
        }
    }
}
