using System.Net.Http.Json;
using Shared.DTOs.GradAdjustment;
using Web.Services.Interfaces;

namespace Web.Services;

public class GradeService : IGradeService
{
    private readonly HttpClient _client;

    public GradeService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<GradeAdjustmentListDto>?> GetAll()
    {
        List<GradeAdjustmentListDto>? resp = await _client.GetFromJsonAsync<List<GradeAdjustmentListDto>>("api/grade-adjustments");

        return resp;
    }
}
