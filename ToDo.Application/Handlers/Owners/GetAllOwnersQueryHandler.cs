using MediatR;
using ToDo.Application.Commands;
using ToDo.Application.Commands.Owners;
using ToDo.Application.Services.Interfaces;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Application.Handlers.Owners;

public class GetAllOwnersQueryHandler(IOwnerService ownerService) : IRequestHandler<GetAllOwnersQuery, List<OwnerDto>>
{
    public async Task<List<OwnerDto>> Handle(GetAllOwnersQuery request, CancellationToken cancellationToken)
    {
        var result = await ownerService.GetAllAsync();
        return result.ToList();
    }
}