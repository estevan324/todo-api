using AutoMapper;
using ToDo.Domain.Domain.Entities;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Application.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        _ = CreateMap<OwnerEntity, OwnerDto>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opts => opts.MapFrom((src => src.Email)))
            .ReverseMap();
    }
}