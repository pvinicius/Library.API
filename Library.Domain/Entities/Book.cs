
using Library.Domain.DTO;

namespace Library.Domain.Entities
{
    public class Book
    {
        public Book() { }

        public Book(BookDTO bookDTO)
        {
            BookId = bookDTO.BookId;
            Name = bookDTO.Name;
            AuthorId = bookDTO.AuthorId;
            BookCategoryId = bookDTO.BookCategoryId;
        }

        public int BookId { get; private set; }
        public string Name { get; private set; }
        public int AuthorId { get; private set; }
        public int BookCategoryId { get; private set; }
        public Author Author { get; private set; }
        public BookCategory BookCategory { get; private set; }

    }
}
