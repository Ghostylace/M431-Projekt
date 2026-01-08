using Shared.DTOs;

namespace API.Services.Abstract;

public interface IProrectorService
{
    Task<List<LookupDto>> GetAllAsync();
}

