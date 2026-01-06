using API.Models;
using API.Services.Abstract;
using Shared.DTOs;
using Supabase;

namespace API.Services;

public class TeacherService : ITeacherService
{
    private readonly Client _supabase;

    public TeacherService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<LookupDto>> GetAllAsync()
    {
        var response = await _supabase
            .From<Teacher>()
            .Get();

        return response.Models
            .Select(t => new LookupDto
            {
                Id = t.Id,
                DisplayName = $"{t.FirstName} {t.LastName}"
            })
            .OrderBy(x => x.DisplayName)
            .ToList();
    }
}
