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

    public async Task<List<GradeAdjustmentDto>?> GetAll()
    {
        List<GradeAdjustmentDto>? resp = await _client.GetFromJsonAsync<List<GradeAdjustmentDto>>("api/grade-adjustments");

        return resp;
    }

    public async Task<bool> AddGrade(CreateGradeAdjustmentRequest grade)
    {
        HttpResponseMessage resp = await _client.PostAsJsonAsync("api/grade-adjustments", grade);
        return resp.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateStatus(UpdateGradeAdjustmentStatusRequest grade)
    {
        HttpResponseMessage resp = await _client.PutAsJsonAsync($"api/grade-adjustments/{grade.Id}", grade);
        return resp.IsSuccessStatusCode;
    }
}
