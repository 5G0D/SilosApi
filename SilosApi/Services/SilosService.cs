using AutoMapper;
using SilosApi.Dto;
using SilosApi.Entities;
using SilosApi.Repositories;

namespace SilosApi.Services;

public class SilosService(ISilosRepository repository, IMapper mapper) : ISilosService
{
    public async Task<IEnumerable<SilosDto>> GetAllSilosAsync(SilosFilterDto? silosFilterDto)
    {
        var silosList = await repository.GetAllAsync(silosFilterDto);
        return mapper.Map<IEnumerable<SilosDto>>(silosList);
    }

    public async Task<SilosDto?> GetSilosByIdAsync(int id)
    {
        var silos = await repository.GetByIdAsync(id);
        return silos == null ? null : mapper.Map<SilosDto>(silos);
    }

    public async Task<SilosDto> CreateSilosAsync(SilosDto silosDto)
    {
        var silos = mapper.Map<Silos>(silosDto);
        var createdSilos = await repository.CreateAsync(silos);
        return mapper.Map<SilosDto>(createdSilos);
    }

    public async Task<bool> UpdateSilosAsync(SilosDto silosDto)
    {
        var silos = mapper.Map<Silos>(silosDto);
        return await repository.UpdateAsync(silos);
    }

    public async Task<bool> DeleteSilosAsync(int id)
    {
        return await repository.DeleteAsync(id);
    }
}