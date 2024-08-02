using System.Text.Json.Serialization;

namespace Almoussawi.Domain.Models
{
    public class Category
    {
        public string Id { get; set; }
        [JsonIgnore]
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
