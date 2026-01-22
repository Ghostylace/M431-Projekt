using API.Models;
using API.Services.Abstract;
using Supabase.Postgrest.Responses;
using Shared.DTOs.Module;
using Supabase;

namespace API.Services;

public class ModuleService : IModuleService
{
    private readonly Client _supabase;

    public ModuleService(Client supabase)
    {
        _supabase = supabase;
    }

    /// <summary>
    /// The get method to get all modules
    /// </summary>
    /// <returns><see cref="List{T}"/> instance with type <see cref="ModuleDto"/></returns>
    public async Task<List<ModuleDto>> GetAllAsync()
    {
        ModeledResponse<Module> response = await _supabase
            .From<Module>()
            .Get();

        return response.Models
            .Select(m => new ModuleDto
            {
                Id = m.Id,
                Name = m.Modulname,
                Semester = m.Semester
            })
            .OrderBy(x => x.Id)
            .ToList();
    }
}

