using MediatR;
using ToDo.Application.Commands;
using ToDo.Application.Commands.Owners;
using ToDo.Application.Services.Interfaces;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Application.Handlers.Owners;

public class GetByIdOwnerQueryHandler(IOwnerService ownerService) : IRequestHandler<GetByIdOwnerQuery, OwnerDto>
{
    public async Task<OwnerDto> Handle(GetByIdOwnerQuery request, CancellationToken cancellationToken)
        => await ownerService.GetByIdAsync(request.Id);
}