using Shared.DTOs.Prorektor;

namespace API.Services.Abstract;

public interface IProrectorService
{
    Task<List<ProrektorDTO>> GetAllAsync();
}

