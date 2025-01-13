using MediatR;
using ToDo.Application.Commands;
using ToDo.Application.Services.Interfaces;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Application.Handlers;

public class UpdateOwnerCommandHandler(IOwnerService ownerService) : IRequestHandler<UpdateOwnerCommand, OwnerDto>
{
    public async Task<OwnerDto> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
    {
        var ownerRequest = new OwnerDto(
            Name: request.Name,
            Email: request.Email,
            Id: request.Id);

        await ownerService.UpdateAsync(ownerRequest);

        return await ownerService.GetByIdAsync(request.Id);
    }
}