using Shared.DTOs;
using Shared.DTOs.Prorektor;

namespace API.Services.Abstract;

public interface IProrectorService
{
    Task<List<LookupDto>> GetAllAsync();
}

