using System;
using Library.Domain.Entities;
using Library.Infrastructure.Maps;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Contexts
{
    public class LibraryDataContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<Author> Author { get; set; }

        public LibraryDataContext()
        {

        }

        public LibraryDataContext(DbContextOptions<LibraryDataContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RG4EOGV;Initial Catalog=Library;Integrated Security=True;Pooling=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AuthorMap());
            builder.ApplyConfiguration(new BookMap());
            builder.ApplyConfiguration(new BookCategoryMap());
        }

    }
}
