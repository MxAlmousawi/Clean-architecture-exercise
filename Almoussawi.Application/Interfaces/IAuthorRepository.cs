using Almoussawi.Domain.Models;
using Almoussawi.Shared;
using WebApiExercise.Models.DTO.Author;


namespace WebApiExercise.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        public Task<Response<List<Author>>> GetAll();
        public Task<Response<Author>> GetById(Guid authorId);
        public Task<Response<Author>> Add(AddAuthorDto authorDto);
        public Task<Response<Author>> Update(Guid authorId, UpdateAuthorDto authorDto);
        public Task<Response<Author>> Delete(Guid authorId);
    }
}
