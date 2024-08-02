using Almoussawi.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiExercise.Models.DTO.Author;
using WebApiExercise.Models.DTO.Book;

namespace Almoussawi.Application.Mapster
{

public class MappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Book, BookDto>.NewConfig()
                .Map(dest => dest.AuthorNav, src => src.AuthorNav)
                .Map(dest => dest.BookCategories, src => src.BookCategories.Select(bc => bc.CategoryId).ToList());

            TypeAdapterConfig<Author, AuthorDto>.NewConfig();
        }
    }

}
