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

namespace Almoussawi.Application.Queries.BookQueries
{
    public record GetAllBooksQuery:IRequest<Response<List<BookDto>>>;

    public class GetAllBooksHandler:IRequestHandler<GetAllBooksQuery, Response<List<BookDto>>>
    {
        private readonly IBookRepository bookRepository;

        public GetAllBooksHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<Response<List<BookDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books =  await bookRepository.GetAll();
            return books.Adapt<Response<List<BookDto>>>();
        }
    }
}
