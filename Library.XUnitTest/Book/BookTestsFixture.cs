using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Library.XUnitTest.Book
{
    #region usings
    using Author;
    using Bogus;
    using BookCategory;
    using Const;
    using Domain.Entities;
    #endregion

    [CollectionDefinition(nameof(BookCollection))]
    public class BookCollection : ICollectionFixture<BookTestsFixture> { }

    public class BookTestsFixture : IDisposable
    {
        public IEnumerable<Book> GenerateBooks(int quantity = 1)
        {
            var bookFaker = new Faker<Book>(Locales.PT_BR)
                .StrictMode(true)
                .RuleFor(x => x.Id, y => y.Random.Number(1, int.MaxValue))
                .RuleFor(x => x.Name, y => y.Lorem.Word())
                .RuleFor(x => x.AuthorId, y => y.Random.Number(1, int.MaxValue))
                .RuleFor(x => x.Author, new Author())
                .RuleFor(x => x.BookCategoryId, y => y.Random.Number(1, int.MaxValue))
                .RuleFor(x => x.BookCategory, new BookCategory());

            return bookFaker.Generate(quantity);
        }

        public void Dispose() { }
    }
}
