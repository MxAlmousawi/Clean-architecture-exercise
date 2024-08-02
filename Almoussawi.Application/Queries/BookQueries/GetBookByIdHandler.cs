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

namespace Almoussawi.Application.Queries.BookQueries
{
    public record GetBookByIdQuery(Guid bookId) : IRequest<Response<BookDto>>;

    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery ,Response<BookDto>>
    {
        private readonly IBookRepository bookRepository;

        public GetBookByIdHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<Response<BookDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await bookRepository.GetById(request.bookId);
            return book.Adapt<Response<BookDto>>();
        }
    }
}
