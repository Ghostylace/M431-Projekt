using Shared.DTOs.GradAdjustment;

namespace Web.Services.Interfaces
{
    /// <summary>
    /// Interface containing methods for Grade operations
    /// </summary>
    public interface IGradeService
    {
        /// <summary>
        /// Gets all Grades.
        /// </summary>
        /// <returns>returns a list with the grades</returns>
        Task<List<GradeAdjustmentDto>?> GetAll();

        /// <summary>
        /// Adds the grade.
        /// </summary>
        /// <param name="grade">The grade.</param>
        /// <returns>Returns a bool which checks if post suceeded or not</returns>
        Task<bool> AddGrade(CreateGradeAdjustmentRequest grade);

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="grade">The grade.</param>
        /// <returns>returns a bool which checks if put suceeded or not</returns>
        Task<bool> UpdateStatus(UpdateGradeAdjustmentStatusRequest grade);
    }
}