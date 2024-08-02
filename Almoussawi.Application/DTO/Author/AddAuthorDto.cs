﻿using System.ComponentModel.DataAnnotations;

namespace WebApiExercise.Models.DTO.Author
{
    public class AddAuthorDto
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
