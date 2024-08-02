using System.Text.Json.Serialization;

namespace Almoussawi.Domain.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public Author AuthorNav { get; set; }
        [JsonIgnore]
        public ICollection<BookCategory> BookCategories { get; set; } 
    }
}
