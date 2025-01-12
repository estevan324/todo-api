using Microsoft.EntityFrameworkCore;
using ToDo.Infrastructure.Data.Context;
using ToDo.Infrastructure.Repositories;

namespace ToDo.Application.Repositories;

public class Repository<TData>(ApplicationDbContext context) : IRepository<TData> where TData : class
{
    public async Task<IList<TData>> GetAllAsync() 
        => await context.Set<TData>().ToListAsync();

    public async Task<TData?> GetByIdAsync(Guid? id)
        => await context.Set<TData>().FindAsync(id);

    public async Task SaveAsync(TData data)
    {
        if (context.Entry(data).State is EntityState.Detached)
            await context.Set<TData>().AddAsync(data);
        else
            context.Set<TData>().Update(data);

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            context.Set<TData>().Remove(entity); 
            await context.SaveChangesAsync(); 
        }
    }
}