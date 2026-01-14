using API.Models;
using API.Services.Abstract;
using Shared.DTOs.Teacher;
using Supabase;

namespace API.Services;

public class TeacherService : ITeacherService
{
    private readonly Client _supabase;

    public TeacherService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<TeacherDTO>> GetAllAsync()
    {
        Supabase.Postgrest.Responses.ModeledResponse<Teacher> response = await _supabase
            .From<Teacher>()
            .Get();

        return response.Models
            .Select(t => new TeacherDTO
            {
                Id = t.Id,
                Vorname = t.FirstName,
                Nachname= t.LastName
            })
            .OrderBy(x => x.Vorname)
            .ToList();
    }
}
