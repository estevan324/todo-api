using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Commands;
using ToDo.Domain.Models.Dtos;

namespace ToDo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OwnerController(IMediator mediator)
{
    [HttpPost]
    public async Task<ActionResult<OwnerDto>> Post(CreateOwnerCommand command)
    {
        var response = await mediator.Send(command);
        return response;
    }

    [HttpPut]
    public async Task<ActionResult<OwnerDto>> Put(UpdateOwnerCommand command)
    {
        var response = await mediator.Send(command);

        return response;
    }
}