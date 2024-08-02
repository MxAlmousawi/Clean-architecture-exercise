using Almoussawi.Domain.Models;
using Almoussawi.Shared;
using WebApiExercise.Models.DTO.Book;

namespace WebApiExercise.Repository.Interfaces
{
    public interface IBookRepository
    {
        public Task<Response<List<Book>>> GetAll();
        public Task<Response<Book>> GetById(Guid bookId);
        public Task<Response<Book>> Add(AddBookDto bookDto);
        public Task<Response<Book>> Update(Guid bookId , UpdateBookDto bookDto);
        public Task<Response<Book>> Delete(Guid bookId);
    }
}
