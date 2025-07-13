using AutoMapper;
using SilosApi.Dto;
using SilosApi.Entities;

namespace SilosApi.MapProfiles;

public class SilosProfile : Profile
{
    public SilosProfile()
    {
        CreateMap<Silos, SilosDto>();
        CreateMap<SilosDto, Silos>();
    }
}