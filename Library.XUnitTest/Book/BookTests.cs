using System.Linq;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Services;
using Moq.AutoMock;
using Xunit;
/*
namespace Library.XUnitTest.Book
{
    [Collection(nameof(BookCollection))]
    public class BookTests
    {
        private readonly BookTestsFixture _bookTestsFixture;

        public BookTests(BookTestsFixture bookTestsFixture)
        {
            _bookTestsFixture = bookTestsFixture;
        }

        [Fact(DisplayName = "Create Book")]
        public void Book_NewBook_ShouldValid()
        {
            //Arrange
            var book = _bookTestsFixture.GenerateBooks().FirstOrDefault();

            var mocker = new AutoMocker();
            mocker.GetMock<IBookRepository>().Setup(s => s.Add(book)).Returns(() => null);

            var _bookService = mocker.CreateInstance<BookService>();

            //Act
            var actual = _bookService.Add(book);

            //Assert
            Assert.Same(book, actual);
        }

        [Fact(DisplayName = "Update Book")]
        public void Book_UpdateBook_ShouldValid()
        {
            //Arrange
            var book = _bookTestsFixture.GenerateBooks().FirstOrDefault();

            var mocker = new AutoMocker();
            mocker.GetMock<IBookRepository>().Setup(s => s.Update(book)).Returns(() => null);

            var _bookService = mocker.CreateInstance<BookService>();

            //Act
            var actual = _bookService.Update(book);

            //Assert
            Assert.Same(book, actual);
        }

        [Fact(DisplayName = "Delete Book")]
        public void Book_DeleteBook_ShouldValid()
        {
            //Arrange
            var book = _bookTestsFixture.GenerateBooks().FirstOrDefault();

            var mocker = new AutoMocker();
            mocker.GetMock<IBookRepository>().Setup(s => s.Remove(book)).Returns(() => null);

            var _bookService = mocker.CreateInstance<BookService>();

            //Act
            var actual = _bookService.Remove(book);

            //Assert
            Assert.Same(book, actual);
        }

    }
}
*/