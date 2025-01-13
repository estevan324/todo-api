using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Commands;
using ToDo.Application.Commands.Owners;
using ToDo.Domain.Models.Dtos;

namespace ToDo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OwnersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<OwnerDto>>> GetAll()
    {
        var response = await mediator.Send(new GetAllOwnersQuery());
        return response;
    }
    
    [HttpGet("/{id:guid}")]
    public async Task<ActionResult<OwnerDto>> GetById(Guid id)
    {
        var response = await mediator.Send(new GetByIdOwnerQuery(id));
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<OwnerDto>> Post(CreateOwnerCommand command)
    {
        var response = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response.Id},  response);
    }

    [HttpPut]
    public async Task<ActionResult<OwnerDto>> Put(UpdateOwnerCommand command)
    {
        var response = await mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await mediator.Send(new DeleteOwnerCommand(id));
        return NoContent();
    }
}