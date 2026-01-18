using API.Models;
using API.Services.Abstract;
using Supabase.Postgrest.Responses;
using Shared.DTOs.Student;
using Supabase;

namespace API.Services;

public class StudentService : IStudentService
{
    private readonly Client _supabase;

    public StudentService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<StudentListDto>> GetAllAsync()
    {
        ModeledResponse<Student> response = await _supabase
            .From<Student>()
            .Get();

        return response.Models
            .Select(s => new StudentListDto
            {
                Id = s.Id,
                FullName = $"{s.Vorname} {s.Nachname}",
                Klasse = s.Klasse
            })
            .OrderBy(x => x.Id)
            .ToList();
    }
}

