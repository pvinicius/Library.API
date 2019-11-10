using System.Collections.Generic;
using System.Linq;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using Library.Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/v1/books")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public Response<Book> Get() => _bookService.GetAll();

        [HttpGet("{id}")]
        public Response<Book> Get(int id) => _bookService.Get(id);

        [HttpPost]
        public Response<Book> Post([FromBody]BookDTO bookDTO)
        {
            var book = new Book(bookDTO);
            return _bookService.Add(book);
        }

        [HttpPut("{id}")]
        public Response<Book> Put(int id, [FromBody]BookDTO bookDTO)
        {
            bookDTO.BookId = id;
            var book = new Book(bookDTO);

            return _bookService.Update(book);
        }

        [HttpDelete("{id}")]
        public Response<Book> Delete(int id, [FromBody] BookDTO bookDTO)
        {
            bookDTO.BookId = id;
            var book = new Book(bookDTO);

            return _bookService.Remove(book);
        }
    }
}
