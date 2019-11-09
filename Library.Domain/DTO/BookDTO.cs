using System;
namespace Library.Domain.DTO
{
    public class BookDTO
    {
        public BookDTO()
        {
        }

        public int BookId { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int BookCategoryId { get; set; }
    }
}
