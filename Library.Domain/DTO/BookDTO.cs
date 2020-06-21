using System;

namespace Library.Domain.DTO
{
    public class BookDTO
    {
        public BookDTO()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int BookCategoryId { get; set; }
        public Guid ApplicationUserId { get; set; }
    }
}
