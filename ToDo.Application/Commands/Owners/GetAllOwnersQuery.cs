using MediatR;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Application.Commands.Owners;

public class GetAllOwnersQuery : IRequest<List<OwnerDto>> { }