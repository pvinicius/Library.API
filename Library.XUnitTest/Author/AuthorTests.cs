using Library.Domain.DTO;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Services;
using Moq.AutoMock;
using System.Linq;
using Xunit;

namespace Library.XUnitTest.Author
{
    using Domain.Entities;

    [Collection(nameof(AuthorCollection))]

    public class AuthorTests
    {
        private readonly AuthorTestsFixture _authorTestsFixture;

        public AuthorTests(AuthorTestsFixture authorTestsFixture)
        {
            _authorTestsFixture = authorTestsFixture;
        }


        [Fact(DisplayName = "Create Author")]
        public void Author_NewAuthor_ShouldValid()
        {

            //Arrange
            var author = _authorTestsFixture.GenerateAuthors().FirstOrDefault();
            var response = new Response<Author>()
            {
                Success = true,
                Message = "",
                Data = author
            };

            var mocker = new AutoMocker();
            mocker.GetMock<IAuthorRepository>().Setup(s => s.Add(author)).Returns(() => response);

            var _authorService = mocker.CreateInstance<AuthorService>();

            //Act
            var actual = _authorService.Add(author);

            //Assert
            Assert.Same(author, actual.Data);
        }

        [Fact(DisplayName = "Update Author")]
        public void Author_UpdateAuthor_ShouldValid()
        {
            //Arrange
            var author = _authorTestsFixture.GenerateAuthors().FirstOrDefault();
            var response = new Response<Author>()
            {
                Success = true,
                Message = "",
                Data = author
            };

            var mocker = new AutoMocker();
            mocker.GetMock<IAuthorRepository>().Setup(s => s.Update(author)).Returns(() => response);

            var _authorService = mocker.CreateInstance<AuthorService>();

            //Act
            var actual = _authorService.Update(author);

            //Assert
            Assert.Same(author, actual.Data);
        }

        [Fact(DisplayName = "Delete Author")]
        public void Author_DeleteAuthor_ShouldValid()
        {
            //Arrange
            var author = _authorTestsFixture.GenerateAuthors().FirstOrDefault();
            var response = new Response<Author>()
            {
                Success = true,
                Message = "",
                Data = author
            };

            var mocker = new AutoMocker();
            mocker.GetMock<IAuthorRepository>().Setup(s => s.Remove(author)).Returns(() => response);

            var _authorService = mocker.CreateInstance<AuthorService>();

            //Act
            var actual = _authorService.Remove(author);

            //Assert
            Assert.Same(author, actual.Data);
        }
    }
}
