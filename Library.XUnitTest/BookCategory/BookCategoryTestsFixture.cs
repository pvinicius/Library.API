using System;
using System.Collections.Generic;
using Xunit;

namespace Library.XUnitTest.BookCategory
{
    #region usings
    using Bogus;
    using Domain.Entities;
    using Const;
    #endregion

    [CollectionDefinition(nameof(BookCategoryCollection))]
    public class BookCategoryCollection : ICollectionFixture<BookCategoryTestsFixture> { }

    public class BookCategoryTestsFixture : IDisposable
    {
        public IEnumerable<BookCategory> GenerateBookCategories(int quantity = 1)
        {
            var bookCategoryFaker = new Faker<BookCategory>(Locales.PT_BR)
                .StrictMode(true)
                .RuleFor(x => x.BookCategoryId, y => y.Random.Number(0, int.MaxValue))
                .RuleFor(x => x.Name, y => y.Lorem.Word());

            return bookCategoryFaker.Generate(quantity);
        }

        public void Dispose() { }
    }
}
