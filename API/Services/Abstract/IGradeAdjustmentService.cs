using API.Models;
using API.Modelsn;
using Shared.DTOs;

namespace API.Services.Abstract
{
    public interface IGradeAdjustmentService
    {
        Task<GradeAdjustment> CreateAsync(CreateGradeAdjustmentRequest request);
        Task<List<GradeAdjustment>> GetAllAsync();
        Task UpdateStatusAsync(int id, UpdateGradeAdjustmentStatusRequest request);
    }
}
