using Shared.DTOs.Student;

namespace Web.Services.Interfaces
{
    /// <summary>
    /// interface containing Student operations
    /// </summary>
    public interface IStudentService
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Returns a list with all Students</returns>
        Task<List<StudentListDto>?> GetAll();
    }
}