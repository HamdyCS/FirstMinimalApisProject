using FirstMinimalApisProject.Entites;
using Microsoft.EntityFrameworkCore;

namespace FirstMinimalApisProject.Data
{
    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasMany(author => author.Books).WithOne(book => book.Author).HasForeignKey(book => book.AuthorId);

            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<Book>().ToTable("Books");

        }
    }
}
