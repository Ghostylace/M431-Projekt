using Shared.DTOs.Teacher;

namespace Web.Services.Interfaces
{
    /// <summary>
    /// Interface containing test operations
    /// </summary>
    public interface ITest
    {
        /// <summary>
        /// Gets the teachers asynchronous.
        /// </summary>
        /// <returns>Returns a list with teachers</returns>
        Task<List<TeacherDTO>?> GetTeachersAsync();
    }
}


