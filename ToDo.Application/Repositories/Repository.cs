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

    public async Task<TData> SaveAsync(TData data)
    {
        var entry = context.Entry(data);

        if (entry.State == EntityState.Detached)
        {
            var entity = await context.Set<TData>().FindAsync(entry.Property("Id").CurrentValue);

            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
                context.Set<TData>().Update(data);
            }
            else
                await context.Set<TData>().AddAsync(data);
        }
        else
            context.Set<TData>().Update(data);

        await context.SaveChangesAsync();
        return data;
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