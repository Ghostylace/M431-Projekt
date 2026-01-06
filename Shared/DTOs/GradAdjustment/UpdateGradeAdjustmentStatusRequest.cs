namespace Shared.DTOs.GradAdjustment;

public class UpdateGradeAdjustmentStatusRequest
{
    public string Status { get; set; } = string.Empty;
    public string? RejectionReason { get; set; }
}
