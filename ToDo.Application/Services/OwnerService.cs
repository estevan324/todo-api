using AutoMapper;
using ToDo.Application.Services.Interfaces;
using ToDo.Domain.Models.Dtos;
using ToDo.Domain.Models.Entities;
using ToDo.Domain.Models.Exceptions;
using ToDo.Infrastructure.Repositories;

namespace ToDo.Application.Services;

public class OwnerService(IRepository<OwnerEntity> repository, IMapper mapper) : IOwnerService
{
    public async Task<IList<OwnerDto>> GetAllAsync()
    {
        var owners = await repository.GetAllAsync();

        return mapper.Map<IList<OwnerDto>>(owners);
    }

    public async Task<OwnerDto> GetByIdAsync(Guid? id)
    {
        if (id is null)
            throw new BadRequestException("Id must be informed");
        
        var owner = await repository.GetByIdAsync(id);

        if (owner is null)
            throw new NotFoundException("Owner not found");

        return mapper.Map<OwnerDto>(owner);
    }

    public async Task<OwnerDto> AddAsync(OwnerDto owner)
    {
        var data = await repository.SaveAsync(
            mapper.Map<OwnerEntity>(owner));

        return mapper.Map<OwnerDto>(data);
    }

    public async Task UpdateAsync(OwnerDto owner)
    {
        if (owner.Id is null)
            throw new BadRequestException("Id must be informed");

        await GetByIdAsync(owner.Id!);

        await repository.SaveAsync(
            mapper.Map<OwnerEntity>(owner));
    }


    public async Task DeleteAsync(Guid id)
    {
        await GetByIdAsync(id);

        await repository.DeleteAsync(id);
    }
}