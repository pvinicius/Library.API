using Library.Domain.Entities;
using Library.Infrastructure.Maps;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Contexts
{
    public class LibraryDataContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<Author> Author { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost, 1433; Database=Library;User ID=SA;Password=reallyStrongPwd123");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthorMap());
            builder.ApplyConfiguration(new BookMap());
            builder.ApplyConfiguration(new BookCategoryMap());
        }

    }
}
