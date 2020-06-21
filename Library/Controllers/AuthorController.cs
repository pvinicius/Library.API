using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/v1/authors")]
    [Authorize(Policy = "Administrator")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public Response<Author> Get() => _authorService.GetAll();

        [Route("{id}")]
        [HttpGet]
        public Response<Author> Get(int id) => _authorService.Get(id);

        [HttpPost]
        public Response<Author> Post([FromBody]AuthorDTO authorDTO)
        {
            var author = new Author(authorDTO.Id, authorDTO.Name);
            return _authorService.Add(author);
        }

        [HttpPut("{id}")]
        public Response<Author> Put(int id, [FromBody]AuthorDTO authorDTO)
        {
            var author = new Author(id, authorDTO.Name);

            return _authorService.Update(author);
        }

        [HttpDelete("{id}")]
        public Response<Author> Delete(int id, [FromBody]AuthorDTO authorDTO)
        {
            var author = new Author(id, authorDTO.Name);

            return _authorService.Remove(author);
        }
    }
}
