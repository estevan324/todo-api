using MediatR;
using ToDo.Application.Commands.Owners;
using ToDo.Application.Services.Interfaces;

namespace ToDo.Application.Handlers.Owners;

public class DeleteOwnerCommandHandler(IOwnerService ownerService) : IRequestHandler<DeleteOwnerCommand>
{
    public async Task Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
        => await ownerService.DeleteAsync(request.Id);
}