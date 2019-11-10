using System;
using System.Collections.Generic;
using Xunit;

namespace Library.XUnitTest.Author
{
    #region usings
    using Bogus;
    using Const;
    using Domain.Entities;
    #endregion

    [CollectionDefinition(nameof(AuthorCollection))]
    public class AuthorCollection : ICollectionFixture<AuthorTestsFixture> { }

    public class AuthorTestsFixture : IDisposable
    {

        public IEnumerable<Author> GenerateAuthors(int quantity = 1)
        {
            var authorFaker = new Faker<Author>(Locales.PT_BR)
                .StrictMode(true)
                .RuleFor(x => x.AuthorId, y => y.Random.Number(0, int.MaxValue))
                .RuleFor(x => x.Name, y => string.Format("{0}, {1}", y.Name.LastName(), y.Name.FirstName()));

            return authorFaker.Generate(quantity);
        }

        public void Dispose() { }
    }
}
