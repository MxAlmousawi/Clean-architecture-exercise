

using Almoussawi.Domain.Models;
using WebApiExercise.Models.DTO.Author;

namespace WebApiExercise.Models.DTO.Book
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; }

        public AuthorDto AuthorNav { get; set; }
        public List<string> BookCategories { get; set; }
    }
}
