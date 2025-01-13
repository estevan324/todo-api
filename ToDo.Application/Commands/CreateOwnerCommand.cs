using System.Text.Json.Serialization;
using MediatR;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Application.Commands;

[method: JsonConstructor]
public class CreateOwnerCommand(string name, string email) : IRequest<OwnerDto>
{
    [JsonPropertyName("name")] 
    public string Name { get; private set; } = name;

    [JsonPropertyName("email")] 
    public string Email { get; private set; } = email;
}
    