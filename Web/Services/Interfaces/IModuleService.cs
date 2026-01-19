using Shared.DTOs.Module;

namespace Web.Services.Interfaces
{
    /// <summary>
    /// interface containing Module operations
    /// </summary>
    public interface IModuleService
    {
        /// <summary>
        /// Gets all Modules.
        /// </summary>
        /// <returns>Returns a list with all the modules</returns>
        Task<List<ModuleDto>?> GetAll();
    }
}