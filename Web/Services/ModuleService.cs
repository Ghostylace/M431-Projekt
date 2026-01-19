using System.Net.Http.Json;
using Shared.DTOs.Module;
using Web.Services.Interfaces;

namespace Web.Services;

/// <summary>
/// Handles Module requests
/// </summary>
/// <seealso cref="Web.Services.Interfaces.IModuleService" />
public class ModuleService : IModuleService
{
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="ModuleService"/> class.
    /// </summary>
    /// <param name="client">The client.</param>
    public ModuleService(HttpClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Gets all modules.
    /// </summary>
    /// <returns>returns a list of modules</returns>
    public async Task<List<ModuleDto>?> GetAll()
    {
        List<ModuleDto>? resp = await _client.GetFromJsonAsync<List<ModuleDto>>("api/modules");

        return resp;
    }
}
