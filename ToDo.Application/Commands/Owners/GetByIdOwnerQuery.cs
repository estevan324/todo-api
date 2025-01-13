using System.Text.Json.Serialization;
using MediatR;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Application.Commands.Owners;
public record GetByIdOwnerQuery(Guid Id) : IRequest<OwnerDto>;