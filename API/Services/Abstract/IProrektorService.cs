using Shared.DTOs.Prorektor;

namespace API.Services.Abstract;

public interface IProrektorService
{
    Task<List<ProrektorDTO>> GetAll();
}
