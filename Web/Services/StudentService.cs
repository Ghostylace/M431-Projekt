using System.Net.Http.Json;
using Shared.DTOs.Student;
using Web.Services.Interfaces;

namespace Web.Services;

public class StudentService : IStudentService
{
    private readonly HttpClient _client;

    public StudentService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<StudentListDto>?> GetAll()
    {
        List<StudentListDto>? resp = await _client.GetFromJsonAsync<List<StudentListDto>>("api/students");

        return resp;
    }
}
