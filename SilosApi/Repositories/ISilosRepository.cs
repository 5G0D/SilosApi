using SilosApi.Dto;
using SilosApi.Entities;

namespace SilosApi.Repositories;

public interface ISilosRepository
{
    Task<IEnumerable<Silos>> GetAllAsync(SilosFilterDto? silosFilterDto);
    Task<Silos?> GetByIdAsync(int id);
    Task<Silos> CreateAsync(Silos silos);
    Task<bool> UpdateAsync(Silos silos);
    Task<bool> DeleteAsync(int id);
}