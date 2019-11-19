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
            optionsBuilder.UseSqlServer(@"Server=localhost, 1433; Database=Library; Integrated Security=true; Trusted_Connection=false; User ID=SA;Password=reallyStrongPwd123;");
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
