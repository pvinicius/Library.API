﻿using Library.Domain.Interfaces.Repositories;
using Library.Domain.Services;
using Moq.AutoMock;
using System.Linq;
using Xunit;

namespace Library.XUnitTest.BookCategory
{
    using Domain.Entities;
    using Library.Domain.DTO;

    [Collection(nameof(BookCategoryCollection))]
    public class BookCategoryTests
    {

        private readonly BookCategoryTestsFixture _bookCategoryTestsFixture;

        public BookCategoryTests(BookCategoryTestsFixture bookCategoryTestsFixture)
        {
            _bookCategoryTestsFixture = bookCategoryTestsFixture;
        }


        [Fact(DisplayName = "Create Book Category")]
        public void BookCategory_NewBookCategory_ShouldValid()
        {

            //Arrange
            var bookCategory = _bookCategoryTestsFixture.GenerateBookCategories().FirstOrDefault();
            var response = new Response<BookCategory>()
            {
                Success = true,
                Message = "",
                Data = bookCategory
            };

            var mocker = new AutoMocker();
            mocker.GetMock<IBookCategoryRepository>().Setup(s => s.Add(bookCategory)).Returns(() => response);

            var _bookCategoryService = mocker.CreateInstance<BookCategoryService>();

            //Act
            var actual = _bookCategoryService.Add(bookCategory);

            //Assert
            Assert.Same(bookCategory, actual.Data);
        }

        [Fact(DisplayName = "Update Book Category")]
        public void BookCategory_UpdateBookCategory_ShouldValid()
        {
            //Arrange
            var bookCategory = _bookCategoryTestsFixture.GenerateBookCategories().FirstOrDefault();
            var response = new Response<BookCategory>()
            {
                Success = true,
                Message = "",
                Data = bookCategory
            };

            var mocker = new AutoMocker();
            mocker.GetMock<IBookCategoryRepository>().Setup(s => s.Update(bookCategory)).Returns(() => response);

            var _bookCategoryService = mocker.CreateInstance<BookCategoryService>();

            //Act
            var actual = _bookCategoryService.Update(bookCategory);

            //Assert
            Assert.Same(bookCategory, actual.Data);
        }

        [Fact(DisplayName = "Delete Book Category")]
        public void BookCategory_DeleteBookCategory_ShouldValid()
        {
            //Arrange
            var bookCategory = _bookCategoryTestsFixture.GenerateBookCategories().FirstOrDefault();
            var response = new Response<BookCategory>()
            {
                Success = true,
                Message = "",
                Data = bookCategory
            };

            var mocker = new AutoMocker();
            mocker.GetMock<IBookCategoryRepository>().Setup(s => s.Remove(bookCategory)).Returns(() => response);

            var _bookCategoryService = mocker.CreateInstance<BookCategoryService>();

            //Act
            var actual = _bookCategoryService.Remove(bookCategory);

            //Assert
            Assert.Same(bookCategory, actual.Data);
        }

    }
}
