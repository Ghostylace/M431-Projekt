namespace Shared.DTOs.GradAdjustment;

public class UpdateGradeAdjustmentStatusRequest
{
    public int Id { get; set; }
    public string Status { get; set; } = "";
    public string? DecisionRemark { get; set; }
}
