using MediatR;
using ToDo.Application.Commands;
using ToDo.Application.Commands.Owners;
using ToDo.Application.Services.Interfaces;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Application.Handlers.Owners;

public class CreateOwnerCommandHandler(IOwnerService ownerService) 
    : IRequestHandler<CreateOwnerCommand, OwnerDto>
{
    public async Task<OwnerDto> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {
        var ownerRequest = new OwnerDto(
            Name:request.Name, 
            Email: request.Email);

        var data = await ownerService.AddAsync(ownerRequest);

        return data;
    }
}