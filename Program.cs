using FirstMinimalApiProject.EndPoints;
using FirstMinimalApisProject.Contracks;
using FirstMinimalApisProject.Data;
using FirstMinimalApisProject.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddDbContext<AppDbContex>(opt => opt.UseSqlServer("server=.;Database=BooksDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;"));

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.MapAppEndPoints();

app.Run();


