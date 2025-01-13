using AutoMapper;
using ToDo.Application.Services.Interfaces;
using ToDo.Domain.Models.Dtos;
using ToDo.Domain.Models.Entities;
using ToDo.Domain.Models.Exceptions;
using ToDo.Infrastructure.Repositories;

namespace ToDo.Application.Services;

public class ToDoService(IRepository<ToDoEntity> repository, IMapper mapper) : IToDoService
{
    public async Task<IList<ToDoDto>> GetAllAsync()
    {
        var toDos = await repository.GetAllAsync();

        return mapper.Map<IList<ToDoDto>>(toDos);
    }

    public async Task<ToDoDto> GetByIdAsync(Guid? id)
    {
        if (id is null)
            throw new BadRequestException("Id must be informed");
        
        var toDo = await repository.GetByIdAsync(id);

        if (toDo is null)
            throw new NotFoundException("Owner not found");

        return mapper.Map<ToDoDto>(toDo);
    }

    public async Task<ToDoDto> AddAsync(ToDoDto todo)
    {
        var data = await repository.SaveAsync(
            mapper.Map<ToDoEntity>(todo));

        return mapper.Map<ToDoDto>(data);
    }

    public async Task UpdateAsync(ToDoDto todo)
    {
        if (todo.Id is null)
            throw new BadRequestException("Id must be informed");

        await GetByIdAsync(todo.Id!);

        await repository.SaveAsync(
            mapper.Map<ToDoEntity>(todo));
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}