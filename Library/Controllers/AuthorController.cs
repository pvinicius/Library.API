using System.Collections.Generic;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/v1/authors")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IEnumerable<Author> Get() => _authorService.GetAll();

        [Route("{id}")]
        [HttpGet]
        public Author Get(int id) => _authorService.Get(id);


        [HttpPost]
        public Author Post([FromBody]AuthorDTO authorDTO)
        {
            var author = new Author(authorDTO);
            return _authorService.Add(author);
        }

        [HttpPut("{id}")]
        public Author Put(int id, [FromBody]AuthorDTO authorDTO)
        {
            authorDTO.AuthorId = id;
            var author = new Author(authorDTO);

            return _authorService.Update(author);
        }

        [HttpDelete("{id}")]
        public Author Delete(int id, [FromBody]AuthorDTO authorDTO)
        {
            authorDTO.AuthorId = id;
            var author = new Author(authorDTO);

            return _authorService.Remove(author);
        }
    }
}
