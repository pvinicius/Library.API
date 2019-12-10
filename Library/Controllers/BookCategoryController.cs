using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/v1/book-categories")]
    [Authorize("Bearer")]
    public class BookCategoryController : Controller
    {
        private readonly IBookCategoryService _bookCategoryService;
        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        [HttpGet]
        public Response<BookCategory> Get() => _bookCategoryService.GetAll();

        [Route("{id}")]
        [HttpGet]
        public Response<BookCategory> Get(int id) => _bookCategoryService.Get(id);

        [HttpPost]
        public Response<BookCategory> Post([FromBody]BookCategoryDTO bookCategoryDTO)
        {
            var bookCategory = new BookCategory(bookCategoryDTO);
            return _bookCategoryService.Add(bookCategory);
        }

        [HttpPut("{id}")]
        public Response<BookCategory> Put(int id, [FromBody]BookCategoryDTO bookCategoryDTO)
        {
            bookCategoryDTO.BookCategoryId = id;
            var bookCategory = new BookCategory(bookCategoryDTO);

            return _bookCategoryService.Update(bookCategory);
        }

        [HttpDelete("{id}")]
        public Response<BookCategory> Delete(int id, [FromBody]BookCategoryDTO bookCategoryDTO)
        {
            bookCategoryDTO.BookCategoryId = id;
            var bookCategory = new BookCategory(bookCategoryDTO);

            return _bookCategoryService.Remove(bookCategory);
        }
    }
}
