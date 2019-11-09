using System.Collections.Generic;
using System.Linq;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/v1/books")]
    public class BookController : Controller
    {
        private readonly LibraryDataContext _context;

        public BookController(LibraryDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _context.Book
                    .AsNoTracking()
                    .ToList();
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _context.Book
                .Where(a => a.BookId == id)
                .FirstOrDefault();
        }

        [HttpPost]
        public Book Post([FromBody]BookDTO bookDTO)
        {

            var book = new Book(bookDTO);

            _context.Book.Add(book);
            _context.SaveChanges();

            return book;
        }

        [HttpPut("{id}")]
        public Book Put(int id, [FromBody]BookDTO bookDTO)
        {
            bookDTO.BookId = id;
            var book = new Book(bookDTO);

            _context.Entry<Book>(book).State = EntityState.Modified;
            _context.SaveChanges();

            return book;
        }

        [HttpDelete("{id}")]
        public Book Delete(int id, [FromBody] BookDTO bookDTO)
        {
            bookDTO.BookId = id;
            var book = new Book(bookDTO);

            _context.Book.Remove(book);
            _context.SaveChanges();

            return book;
        }
    }
}
