using Almoussawi.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApiExercise.Models.DTO.Book
{
    public class UpdateBookDto
    {
        [Required]
        [MinLength(2)]
        public string Title { get; set; }
        [Required]
        public Guid AuthorId { get; set; }

        public List<string> Categories { get; set; }
    }
}
