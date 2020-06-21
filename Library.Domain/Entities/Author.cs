namespace Library.Domain.Entities
{
    public class Author
    {
        public Author() { }

        public Author(Author author)
        {
            Id = author.Id;
            Name = author.Name;
        }

        public Author(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
