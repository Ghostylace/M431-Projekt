using System.Net.Http.Json;
using Shared.DTOs.Module;
using Web.Services.Interfaces;

namespace Web.Services;

public class ModuleService : IModuleService
{
    private readonly HttpClient _client;

    public ModuleService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<ModuleDto>?> GetAll()
    {
        List<ModuleDto>? resp = await _client.GetFromJsonAsync<List<ModuleDto>>("api/modules");

        return resp;
    }
}
