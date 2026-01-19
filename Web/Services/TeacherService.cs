using System.Net.Http.Json;
using Shared.DTOs.Teacher;
using Web.Services.Interfaces;

namespace Web.Services;

/// <summary>
/// handles teacher requests
/// </summary>
/// <seealso cref="Web.Services.Interfaces.ITeacherService" />
public class TeacherService : ITeacherService
{
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="TeacherService"/> class.
    /// </summary>
    /// <param name="client">The client.</param>
    public TeacherService(HttpClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Gets all teachers.
    /// </summary>
    /// <returns>returns a list of teachers</returns>
    public async Task<List<TeacherDTO>?> GetAll()
    {
        List<TeacherDTO>? resp = await _client.GetFromJsonAsync<List<TeacherDTO>>("api/teachers");

        return resp;
    }
}
