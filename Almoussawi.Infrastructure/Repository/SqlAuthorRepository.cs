using Almoussawi.Domain.Models;
using Almoussawi.Shared;
using Microsoft.EntityFrameworkCore;
using WebApiExercise.Data;
using WebApiExercise.Models.DTO.Author;
using WebApiExercise.Repository.Interfaces;

namespace WebApiExercise.Repository.Implementations
{
    public class SqlAuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext dbContext;

        public SqlAuthorRepository(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Response<Author>> Add(AddAuthorDto authorDto)
        {
            var Author = new Author()
            {
                Name = authorDto.Name,
            };
            await dbContext.AddAsync(Author);
            await dbContext.SaveChangesAsync();
            return Response<Author>.Success(Author);
        }

        public async Task<Response<Author>> Delete(Guid authorId)
        {
            var author = await dbContext.Authors.FirstOrDefaultAsync(x => x.Id == authorId);
            if (author == null)
            {
                return Response<Author>.Fail("Author not found");
            }
            dbContext.Authors.Remove(author);
            await dbContext.SaveChangesAsync();
            return Response<Author>.Success(author);
        }

        public async Task<Response<List<Author>>> GetAll()
        {
            var authors = await dbContext.Authors.ToListAsync();
            return Response<List<Author>>.Success(authors);
        }

        public async Task<Response<Author>> GetById(Guid authorId)
        {
            var author = await dbContext.Authors.FirstOrDefaultAsync(x => x.Id == authorId);
            if (author == null)
            {
                return Response<Author>.Success(null);
            }
            return Response<Author>.Success(author);
        }

        public async Task<Response<Author>> Update(Guid authorId, UpdateAuthorDto authorDto)
        {
            var author = await dbContext.Authors.FirstOrDefaultAsync(x => x.Id == authorId);
            if (author == null)
            {
                return Response<Author>.Fail("Author not found");
            }
            author.Name = authorDto.Name;
            await dbContext.SaveChangesAsync();
            return Response<Author>.Success(author);
        }
    }
}
