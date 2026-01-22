namespace Shared.DTOs.GradAdjustment;

public class UpdateGradeAdjustmentStatusRequest
{

    /// <summary>Gets or sets the identifier.</summary>
    public int Id { get; set; }

    /// <summary>Gets or sets the status.</summary>
    public string Status { get; set; } = "";

    /// <summary>Gets or sets the decision remark.</summary>
    public string? DecisionRemark { get; set; }
}
