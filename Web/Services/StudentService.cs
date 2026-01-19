using System.Net.Http.Json;
using Shared.DTOs.Student;
using Web.Services.Interfaces;

namespace Web.Services;

/// <summary>
/// handles Student requests
/// </summary>
/// <seealso cref="Web.Services.Interfaces.IStudentService" />
public class StudentService : IStudentService
{
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="StudentService"/> class.
    /// </summary>
    /// <param name="client">The client.</param>
    public StudentService(HttpClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Gets all students.
    /// </summary>
    /// <returns>returns a list of students</returns>
    public async Task<List<StudentListDto>?> GetAll()
    {
        List<StudentListDto>? resp = await _client.GetFromJsonAsync<List<StudentListDto>>("api/students");

        return resp;
    }
}
