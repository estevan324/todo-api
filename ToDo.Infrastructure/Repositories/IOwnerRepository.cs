using ToDo.Domain.Models.Dtos;

namespace ToDo.Infrastructure.Repositories;

public interface IOwnerRepository
{
    Task<IEnumerable<OwnerDto>> GetAllAsync();
    Task<OwnerDto?> GetByIdAsync(Guid id);
    Task SaveAsync(OwnerDto owner);
    Task DeleteAsync(Guid id);
}