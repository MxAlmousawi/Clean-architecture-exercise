
using Microsoft.EntityFrameworkCore;
using WebApi.Repository.Implementations;
using WebApi.Repository.Interfaces;
using WebApiExercise.Data;
using WebApiExercise.Repository.Implementations;
using WebApiExercise.Repository.Interfaces;
using Almoussawi.Application.Commands.BookCommands;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Almoussawi.Application.Mapster;
using Almoussawi.Domain.Validations;
using Almoussawi.Domain.Models;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace Almoussawi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MappingConfig.RegisterMappings();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IValidator<Book>, BookValidator>();
            builder.Services.AddTransient<IValidator<Author>, AuthorValidator>();
            builder.Services.AddTransient<IValidator<Category>, CategoryValidator>();

            builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));


            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddBookCommand).Assembly));


            builder.Services.AddScoped<IAuthorRepository, SqlAuthorRepository>();
            builder.Services.AddScoped<IBookRepository, SqlBookRepository>();
            builder.Services.AddScoped<ICategoryRepository, SqlCategoryRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
