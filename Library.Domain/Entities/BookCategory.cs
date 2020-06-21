using System;
using Library.Domain.DTO;

namespace Library.Domain.Entities
{
    public class BookCategory
    {
        public BookCategory()
        {
        }

        public BookCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
