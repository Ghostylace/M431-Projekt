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
            .OrderBy(x => x.Name)
            .ToList();
    }
}

