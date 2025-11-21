using FirstMinimalApisProject.Contracks;
using FirstMinimalApisProject.Data;
using FirstMinimalApisProject.Entites;
using Microsoft.EntityFrameworkCore;

namespace FirstMinimalApisProject.Services
{
    public class GenericService<T>(AppDbContex appDbContex, string TableName) : IGenericService<T> where T : class
    {
        public async Task<T> AddNew(T entity)
        {
            try
            {
                await appDbContex.AddAsync(entity);
                await appDbContex.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding new data. TableName = {TableName}", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                IEnumerable<T> result = await appDbContex.Set<T>().ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving data. TableName = {TableName}", ex);
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                T result = await appDbContex.Set<T>().FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving data. TableName = {TableName}", ex);
            }
        }
    }

    public class BookService(AppDbContex appDbContex) : GenericService<Book>(appDbContex, "Books"), IBookService
    {
    }

    public class AuthorService(AppDbContex appDbContex) : GenericService<Author>(appDbContex, "Authors"), IAuthorService
    {
    }
}
