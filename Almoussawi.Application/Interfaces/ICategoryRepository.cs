using Almoussawi.Domain.Models;

namespace WebApi.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAll();
        public Task<Category?> Add(string category);
        public Task<Category?> Delete(string category);
    }
}
