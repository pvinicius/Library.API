
using Library.Domain.DTO;
using System;

namespace Library.Domain.Entities
{
    public class Book
    {
        public Book() { }

        public Book(int id, string name, int authorId, int bookCategoryId, Guid applicationUserId)
        {
            Id = id;
            Name = name;
            AuthorId = authorId;
            BookCategoryId = bookCategoryId;
            ApplicationUserId = applicationUserId;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int AuthorId { get; private set; }
        public int BookCategoryId { get; private set; }
        public Guid ApplicationUserId { get; private set; }
        public Author Author { get; private set; }
        public BookCategory BookCategory { get; private set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
