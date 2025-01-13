using MediatR;

namespace ToDo.Application.Commands.Owners;

public record DeleteOwnerCommand(Guid Id) : IRequest { }