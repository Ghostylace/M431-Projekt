using Shared.DTOs.Module;

namespace API.Services.Abstract;

public interface IModuleService
{
    Task<List<ModuleDto>> GetAllAsync();
}

