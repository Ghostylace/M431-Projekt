using System.Net.Http.Json;
using Shared.DTOs.GradAdjustment;
using Web.Services.Interfaces;

namespace Web.Services;

/// <summary>
/// Handles Grade requests
/// </summary>
/// <seealso cref="Web.Services.Interfaces.IGradeService" />
public class GradeService : IGradeService
{
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="GradeService"/> class.
    /// </summary>
    /// <param name="client">The client.</param>
    public GradeService(HttpClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Gets all grades.
    /// </summary>
    /// <returns>Returns a list of dtos for all grades</returns>
    public async Task<List<GradeAdjustmentDto>?> GetAll()
    {
        List<GradeAdjustmentDto>? resp = await _client.GetFromJsonAsync<List<GradeAdjustmentDto>>("api/grade-adjustments");

        return resp;
    }

    /// <summary>
    /// Adds the grade.
    /// </summary>
    /// <param name="grade">The grade.</param>
    /// <returns>returns a bool which checks if the post suceeded or not</returns>
    public async Task<bool> AddGrade(CreateGradeAdjustmentRequest grade)
    {
        HttpResponseMessage resp = await _client.PostAsJsonAsync("api/grade-adjustments", grade);
        return resp.IsSuccessStatusCode;
    }

    /// <summary>
    /// Updates the grade status.
    /// </summary>
    /// <param name="grade">The grade.</param>
    /// <returns>returns a bool which checks if the put suceeded or not</returns>
    public async Task<bool> UpdateStatus(UpdateGradeAdjustmentStatusRequest grade)
    {
        var payload = new { grade.Status, RejectionReason = grade.DecisionRemark };
        HttpResponseMessage resp = await _client.PutAsJsonAsync($"api/grade-adjustments/status{grade.Id}", payload);
        return resp.IsSuccessStatusCode;
    }
}
