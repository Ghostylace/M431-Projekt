using System.Net.Http.Json;
using Shared.DTOs.Prorektor;
using Web.Services.Interfaces;

namespace Web.Services;

public class Vice_RectorateService : IVice_RectorateService
{
    private readonly HttpClient _client;

    public Vice_RectorateService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<ProrektorDTO>?> GetAll()
    {
        List<ProrektorDTO>? resp = await _client.GetFromJsonAsync<List<ProrektorDTO>>("api/prorectors");

        return resp;
    }
}
