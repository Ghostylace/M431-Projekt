using Shared.DTOs.GradAdjustment;

namespace Web.Services.Interfaces
{
    public interface IGradeService
    {
        Task<List<GradeAdjustmentDto>?> GetAll();
        Task<bool> AddGrade(CreateGradeAdjustmentRequest grade);

        Task<bool> UpdateStatus(UpdateGradeAdjustmentStatusRequest grade);
    }
}