using Shared.DTOs.Student;

namespace Web.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentListDto>?> GetAll();
    }
}