using Almoussawi.Domain.Models;
using Almoussawi.Shared;
using Microsoft.EntityFrameworkCore;
using WebApiExercise.Data;
using WebApiExercise.Models.DTO.Book;
using WebApiExercise.Repository.Interfaces;

namespace WebApiExercise.Repository.Implementations
{
    public class SqlBookRepository : IBookRepository
    {
        private readonly LibraryDbContext dbContext;

        public SqlBookRepository(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Response<Book>> Add(AddBookDto bookDto)
        {
            var book = new Book
            {
                AuthorId = bookDto.AuthorId,
                Title = bookDto.Title,
            };
            await dbContext.Books.AddAsync(book);

            var categories = bookDto.Categories;
            using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                foreach (var category in categories)
                {
                    var bookCategory = new BookCategory()
                    {
                        BookId = book.Id,
                        CategoryId = category
                    };
                    dbContext.Add(bookCategory);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Response<Book>.Fail(ex.Message);
            }
            await dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            return Response<Book>.Success(book);
        }

        public async Task<Response<Book>> Delete(Guid bookId)
        {
            var book = dbContext.Books.FirstOrDefault(x => x.Id == bookId);
            if (book == null)
            {
                return Response<Book>.Success(null);
            }
            dbContext.Books.Remove(book);
            await dbContext.SaveChangesAsync();
            return Response<Book>.Success(book);
        }

        public async Task<Response<List<Book>>> GetAll()
        {
            var books = await dbContext.Books.Include(x => x.BookCategories).ToListAsync();
            return Response<List<Book>>.Success(books);
        }

        public async Task<Response<Book>> GetById(Guid bookId)
        {
            var book = await dbContext.Books.Include(x => x.BookCategories).FirstOrDefaultAsync(x => x.Id == bookId);
            if (book == null)
            {
                return Response<Book>.Success(null);
            }
            return Response<Book>.Success(book);
        }

        public async Task<Response<Book>> Update(Guid bookId, UpdateBookDto bookDto)
        {
            var book = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            if (book == null)
            {
                return Response<Book>.Fail("Book doesn't exist");
            }
            book.AuthorId = bookDto.AuthorId;
            book.Title = bookDto.Title;

            var categories = bookDto.Categories;
            using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                foreach (var category in categories)
                {
                    var bookCategory = new BookCategory()
                    {
                        BookId = book.Id,
                        CategoryId = category
                    };
                    dbContext.Add(bookCategory);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return Response<Book>.Fail(ex.Message);
            }
            await dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            return Response<Book>.Success(book);
        }


    }
}
