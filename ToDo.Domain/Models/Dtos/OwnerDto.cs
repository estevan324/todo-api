namespace ToDo.Domain.Models.Dtos;

public record OwnerDto(
    Guid? Id,
    string Name,
    string Email);