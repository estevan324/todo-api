using ToDo.Domain.Domain.Enums;

namespace ToDo.Domain.Models.Dtos;

public record ToDoDto(
    string Title,
    string Description,
    Status Status,
    DateTime DueDate,
    int Priority,
    OwnerDto Owner,
    Guid? Id = null);