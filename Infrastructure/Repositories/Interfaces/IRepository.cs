namespace Syrla.Api.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();

    Task AddAsync(T entity);

    Task SaveChangesAsync();
}
