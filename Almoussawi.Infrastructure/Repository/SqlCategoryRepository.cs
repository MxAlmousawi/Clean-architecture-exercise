using Almoussawi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Repository.Interfaces;
using WebApiExercise.Data;

namespace WebApi.Repository.Implementations
{
    public class SqlCategoryRepository : ICategoryRepository
    {
        private readonly LibraryDbContext dbContext;

        public SqlCategoryRepository(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category?> Add(string category)
        {
            var cat = new Category()
            {
                Id = category,
            };
            await dbContext.Categories.AddAsync(cat);
            await dbContext.SaveChangesAsync();
            return cat;
        }

        public async Task<Category?> Delete(string category)
        {
            var categoryDb =await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category);
            if (categoryDb == null)
            {
                return null;
            }
            dbContext.Categories.Remove(categoryDb);
            await dbContext.SaveChangesAsync();
            return categoryDb;
        }

        public async Task<List<Category>> GetAll()
        {
            return await dbContext.Categories.ToListAsync();
        }
    }
}
