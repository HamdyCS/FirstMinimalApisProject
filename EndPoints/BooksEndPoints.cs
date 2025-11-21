using FirstMinimalApisProject.Contracks;
using FirstMinimalApisProject.Entites;
using Microsoft.AspNetCore.Mvc;

namespace FirstMinimalApiProject.EndPoints
{
    public static class BooksEndPoints
    {
        public static WebApplication MapBooksEndPoints(this WebApplication app)
        {
            //get all books
            app.MapGet("/books", async (IBookService bookService) =>
            {
                var Books = await bookService.GetAllAsync();

                if (!Books.Any())
                    return Results.NotFound("No books found.");

                return Results.Ok(Books);

            }).WithName("GetAllBooks");

            //get book by id
            app.MapGet("/books/{Id}", async ([FromRoute] Guid Id, IBookService bookService) =>
            {
                var book = await bookService.GetByIdAsync(Id);

                if (book == null)
                    return Results.NotFound("No books found.");

                return Results.Ok(book);

            }).WithName("GetById");

            //create new book
            app.MapPost("/books", async ([FromBody] Book book, IBookService bookService) =>
            {
                book.Id = Guid.NewGuid();
                var createdBook = await bookService.AddNew(book);
                return Results.CreatedAtRoute("GetById", new { Id = createdBook.Id }, createdBook);
            }).WithName("CreateBook");

            return app;
        }
    }
}
