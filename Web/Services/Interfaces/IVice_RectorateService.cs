using Shared.DTOs.Prorektor;

namespace Web.Services.Interfaces
{
    public interface IVice_RectorateService
    {
        Task<List<ProrektorDTO>?> GetAll();
    }
}