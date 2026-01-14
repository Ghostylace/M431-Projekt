using System.Net.Http.Json;
using Shared.DTOs.Teacher;
using Web.Services.Interfaces;

namespace Web.Services;

public class TeacherService : ITeacherService
{
    private readonly HttpClient _client;

    public TeacherService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<TeacherDTO>?> GetAll()
    {
        List<TeacherDTO>? resp = await _client.GetFromJsonAsync<List<TeacherDTO>>("api/teachers");

        return resp;
    }
}
