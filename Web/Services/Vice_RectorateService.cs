using System.Net.Http.Json;
using Shared.DTOs.Prorektor;
using Web.Services.Interfaces;

namespace Web.Services;

/// <summary>
/// Handles prorector requests
/// </summary>
/// <seealso cref="Web.Services.Interfaces.IVice_RectorateService" />
public class Vice_RectorateService : IVice_RectorateService
{
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="Vice_RectorateService"/> class.
    /// </summary>
    /// <param name="client">The client.</param>
    public Vice_RectorateService(HttpClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Gets all prorectors.
    /// </summary>
    /// <returns>Returns a list of all prorectors</returns>
    public async Task<List<ProrektorDTO>?> GetAll()
    {
        List<ProrektorDTO>? resp = await _client.GetFromJsonAsync<List<ProrektorDTO>>("api/prorectors");

        return resp;
    }
}
