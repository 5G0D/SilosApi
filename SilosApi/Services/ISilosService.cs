using SilosApi.Dto;

namespace SilosApi.Services;

public interface ISilosService
{
    Task<IEnumerable<SilosDto>> GetAllSilosAsync(SilosFilterDto? silosFilterDto);
    Task<SilosDto?> GetSilosByIdAsync(int id);
    Task<SilosDto> CreateSilosAsync(SilosDto silosDto);
    Task<bool> UpdateSilosAsync(SilosDto silosDto);
    Task<bool> DeleteSilosAsync(int id);
}