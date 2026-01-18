using System.Net.Http.Json;
using Shared.DTOs.Teacher;
using Web.Services.Interfaces;

namespace Web.Services;

/// <summary>
/// test requests 
/// </summary>
/// <seealso cref="Web.Services.Interfaces.ITest" />
public class Test : ITest
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="Test"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public Test(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Test method. Testing if it returns Teachers
    /// </summary>
    /// <returns>returns a list of teachers</returns>
    public async Task<List<TeacherDTO>?> GetTeachersAsync() 
    {
        return await _httpClient.GetFromJsonAsync<List<TeacherDTO>>("/api/teachers");
    }
}
