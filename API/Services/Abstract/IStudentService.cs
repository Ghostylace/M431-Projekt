using Shared.DTOs.Student;

namespace API.Services.Abstract;

public interface IStudentService
{
    Task<List<StudentListDto>> GetAllAsync();
}
