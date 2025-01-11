using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Domain.Entities;
using ToDo.Domain.Domain.Exceptions;
using ToDo.Domain.Models.Dtos;
using ToDo.Infrastructure.Data.Context;
using ToDo.Infrastructure.Repositories;

namespace ToDo.Application.Repositories;

public class OwnerRepository(ApplicationDbContext context, IMapper mapper) : IOwnerRepository
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<OwnerDto>> GetAllAsync()
    {
        var owners = await _context.Owners.ToListAsync();

        return _mapper.Map<IEnumerable<OwnerDto>>(owners);
    }
        

    public async Task<OwnerDto?> GetByIdAsync(Guid id)
    {
        var owner = await _context.Owners.FindAsync(id);

        return _mapper.Map<OwnerDto>(owner);
    }

    public async Task SaveAsync(OwnerDto owner)
    {
        var ownerEntity = _mapper.Map<OwnerEntity>(owner);
        if (owner.Id is null)
            await _context.Owners.AddAsync(ownerEntity);
        else
            _context.Owners.Update(ownerEntity);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var owner = await GetByIdAsync(id);
        if (owner is not null)
            _context.Owners.Remove(
                _mapper.Map<OwnerEntity>(owner));

        await _context.SaveChangesAsync();
    }
}