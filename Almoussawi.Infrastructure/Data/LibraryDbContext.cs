using Almoussawi.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApiExercise.Data
{
    public class LibraryDbContext:DbContext
    {

        public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions ):base(dbContextOptions){}

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);  
                entity.Property(b => b.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasKey(bc => new {bc.BookId,bc.CategoryId});
                entity.HasOne(bc => bc.BookNav).WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);
                entity.HasOne(bc => bc.CategoryNav).WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);
            });
        }
    }
}
