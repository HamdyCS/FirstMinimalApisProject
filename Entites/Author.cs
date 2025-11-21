namespace FirstMinimalApisProject.Entites
{
    public class Author
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}


