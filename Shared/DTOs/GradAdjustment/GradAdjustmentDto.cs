namespace Shared.DTOs.GradAdjustment;

public class GradeAdjustmentDto
{
    public int Id { get; set; }
    public int StudentId { get; set; } = 1;
    public int ModuleId { get; set; } = 1;
    public int TeacherId { get; set; } = 1;
    public int ViceId { get; set; } = 1;
    public decimal NewGrade { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Remarks { get; set; } = string.Empty;
    public DateTime? TestDate { get; set; }
    public bool Delayed { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? DecisionRemark { get; set; }
    public bool RoundedUp { get; set; }
}

