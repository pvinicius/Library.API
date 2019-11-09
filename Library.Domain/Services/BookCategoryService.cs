using System;
using System.Collections.Generic;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;

namespace Library.Domain.Services
{
    public class BookCategoryService : ServiceBase<BookCategory>, IBookCategoryService
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;

        public BookCategoryService(IBookCategoryRepository bookCategoryRepository) : base(bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }
    }
}
