namespace ToDo.Domain.Models.Dtos;

public record OwnerDto(
    string Name,
    string Email,
    Guid? Id = null);