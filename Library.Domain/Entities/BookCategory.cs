using System;
using Library.Domain.DTO;

namespace Library.Domain.Entities
{
    public class BookCategory
    {
        public BookCategory()
        {
        }

        public BookCategory(BookCategoryDTO bookCategoryDTO)
        {
            BookCategoryId = bookCategoryDTO.BookCategoryId;
            Name = bookCategoryDTO.Name;
        }

        public int BookCategoryId { get; private set; }
        public string Name { get; private set; }
    }
}
