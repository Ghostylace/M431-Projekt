using API.Models;
using Shared.DTOs.GradAdjustment;

namespace API.Services.Abstract;

public interface IGradeAdjustmentService
{
    Task<GradeAdjustmentDto> CreateAsync(CreateGradeAdjustmentRequest request);
    Task<List<GradeAdjustmentDto>> GetAllAsync();
    Task<bool> UpdateStatusAsync(int id, UpdateGradeAdjustmentStatusRequest request);
}
