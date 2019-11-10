using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/v1/bookcategories")]
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
