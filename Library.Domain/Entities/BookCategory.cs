using System;
namespace Library.Domain.Entities
{
    public class BookCategory
    {
        public BookCategory()
        {
        }

        public int BookCategoryId { get; private set; }
        public string Name { get; private set; }
    }
}
