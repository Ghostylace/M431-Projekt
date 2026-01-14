using Shared.DTOs.Teacher;

namespace Web.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherDTO>?> GetAll();
    }
}