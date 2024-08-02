using System.Text.Json.Serialization;

namespace Almoussawi.Domain.Models
{
    public class BookCategory
    {
        public string CategoryId { get; set; }
        public Guid BookId { get; set; }
        public Category CategoryNav { get; set; }
        [JsonIgnore]
        public Book BookNav { get; set; }


    }
}
