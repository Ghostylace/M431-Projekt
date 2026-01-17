using Shared.DTOs.Module;

namespace Web.Services.Interfaces
{
    public interface IModuleService
    {
        Task<List<ModuleDto>?> GetAll();
    }
}