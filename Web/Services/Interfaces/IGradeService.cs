using Shared.DTOs.GradAdjustment;

namespace Web.Services.Interfaces
{
    public interface IGradeService
    {
        Task<List<GradeAdjustmentListDto>?> GetAll();
    }
}