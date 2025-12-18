using Shared.DTOs.Teacher;

namespace Web.Services.Interfaces;

public interface ITest
{
    Task<List<TeacherDTO>> GetTeachersAsync();
}
