using ToDo.Domain.Models.Dtos;

namespace ToDo.Application.Services.Interfaces;

public interface IToDoService
{
    Task<IList<ToDoDto>> GetAllAsync();
    Task<ToDoDto> GetByIdAsync(Guid? id);
    Task<ToDoDto> AddAsync(ToDoDto todo);
    Task UpdateAsync(ToDoDto todo);
    Task DeleteAsync(Guid id);
}