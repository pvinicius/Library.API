using Library.Domain.DTO;

namespace Library.Domain.Entities
{
    public class Author
    {
        public Author() { }

        public Author(Author author)
        {
            AuthorId = author.AuthorId;
            Name = author.Name;
        }

        public Author(AuthorDTO authorDTO)
        {
            AuthorId = authorDTO.AuthorId;
            Name = authorDTO.Name;
        }

        public int AuthorId { get; private set; }
        public string Name { get; private set; }
    }
}
