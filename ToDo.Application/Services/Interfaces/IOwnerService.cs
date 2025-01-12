using ToDo.Domain.Models.Dtos;

namespace ToDo.Application.Services.Interfaces;

public interface IOwnerService
{
    Task<IList<OwnerDto>> GetAllAsync();
    Task<OwnerDto> GetByIdAsync(Guid? id);
    Task AddAsync(OwnerDto owner);
    Task UpdateAsync(OwnerDto owner);
    Task DeleteAsync(Guid id);
}