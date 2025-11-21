namespace FirstMinimalApisProject.Entites
{
    public class Book
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
