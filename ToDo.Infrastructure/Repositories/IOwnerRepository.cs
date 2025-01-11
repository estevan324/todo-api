using ToDo.Domain.Domain.Entities;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Infrastructure.Repositories;

public interface IOwnerRepository
{
    Task<IEnumerable<OwnerEntity>> GetAllAsync();
    Task<OwnerEntity?> GetByIdAsync(Guid id);
    Task SaveAsync(OwnerEntity owner);
    Task DeleteAsync(Guid id);
}