using Shared.DTOs.Teacher;

namespace API.Services.Abstract;

public interface ITeacherService
{
    Task<List<TeacherDTO>> GetAllAsync();
}
