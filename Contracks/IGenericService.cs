namespace FirstMinimalApisProject.Contracks
{
    public interface IGenericService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T> GetByIdAsync(Guid id);

        public Task<T> AddNew(T entity);
    }
}
