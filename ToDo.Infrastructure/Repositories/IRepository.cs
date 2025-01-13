using ToDo.Infrastructure.Data.Context;

namespace ToDo.Infrastructure.Repositories;

public interface IRepository<T>
{
    Task<IList<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid? id);
    Task<T> SaveAsync(T data);
    Task DeleteAsync(Guid id);    
}