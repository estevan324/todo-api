using System.Text.Json.Serialization;
using MediatR;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Application.Commands.Owners;

[method: JsonConstructor]
public class UpdateOwnerCommand(Guid id, string name, string email) : IRequest<OwnerDto>
{
    [JsonPropertyName("id")]
    public Guid Id { get; private set; } = id;
    
    [JsonPropertyName("name")] 
    public string Name { get; private set; } = name;

    [JsonPropertyName("email")] 
    public string Email { get; private set; } = email;
}