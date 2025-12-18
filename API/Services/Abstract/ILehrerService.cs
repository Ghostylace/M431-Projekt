using Shared.DTOs.Teacher;

namespace API.Services.Abstract
{
    public interface ILehrerService
    {
        Task<List<TeacherDTO>?> GetAllTeachers();
        Task<List<TeacherDTO>?> GetTeacherByEmail(string email);
    }
}