using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Domain.Entities;
using ToDo.Domain.Domain.Exceptions;
using ToDo.Domain.Models.Dtos;
using ToDo.Infrastructure.Data.Context;
using ToDo.Infrastructure.Repositories;

namespace ToDo.Application.Repositories;

public class OwnerRepository(ApplicationDbContext context) : IOwnerRepository
{
    public async Task<IEnumerable<OwnerEntity>> GetAllAsync() 
        => await context.Owners.ToListAsync();


    public async Task<OwnerEntity?> GetByIdAsync(Guid id) 
        => await context.Owners.FindAsync(id);

    public async Task SaveAsync(OwnerEntity owner)
    {
        if (owner.Id is null)
            await context.Owners.AddAsync(owner);
        else
            context.Owners.Update(owner);

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var owner = await GetByIdAsync(id);
        if (owner is not null)
            context.Owners.Remove(owner);

        await context.SaveChangesAsync();
    }
}