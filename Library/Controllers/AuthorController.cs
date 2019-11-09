using System.Collections.Generic;
using System.Linq;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/v1/authors")]
    public class AuthorController : Controller
    {
        private readonly LibraryDataContext _context;

        public AuthorController(LibraryDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _context.Author.AsNoTracking().ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public Author Get(int id)
        {
            return _context.Author.Where(a => a.AuthorId == id).FirstOrDefault();
        }

        [HttpPost]
        public Author Post([FromBody]AuthorDTO authorDTO)
        {
            var author = new Author(authorDTO);

            _context.Author.Add(author);
            _context.SaveChanges();

            return author;
        }

        [HttpPut("{id}")]
        public Author Put(int id, [FromBody]AuthorDTO authorDTO)
        {
            authorDTO.AuthorId = id;
            var author = new Author(authorDTO);
            
            _context.Entry<Author>(author).State = EntityState.Modified;
            _context.SaveChanges();

            return author;

        }

        [HttpDelete("{id}")]
        public Author Delete(int id, [FromBody]AuthorDTO authorDTO)
        {
            authorDTO.AuthorId = id;
            var author = new Author(authorDTO);

            _context.Author.Remove(author);
            _context.SaveChanges();

            return author;
        }
    }
}
