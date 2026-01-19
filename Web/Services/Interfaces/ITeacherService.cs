using Shared.DTOs.Teacher;

namespace Web.Services.Interfaces
{
    /// <summary>
    /// Interface containing operations for teachers
    /// </summary>
    public interface ITeacherService
    {
        /// <summary>
        /// Gets all teachers.
        /// </summary>
        /// <returns>returns a list with all teachers</returns>
        Task<List<TeacherDTO>?> GetAll();
    }
}