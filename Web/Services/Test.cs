using System.Net.Http.Json;
using Shared.DTOs.Teacher;
using Web.Services.Interfaces;

namespace Web.Services;

public class Test : ITest
{
    private readonly HttpClient _httpClient;

    public Test(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<TeacherDTO>?> GetTeachersAsync() 
    {
        return await _httpClient.GetFromJsonAsync<List<TeacherDTO>>("/api/Teacher");
    }
}
