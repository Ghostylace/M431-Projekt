namespace Shared.DTOs.GradAdjustment;

public class GradeAdjustmentDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int ModuleId { get; set; }
    public int TeacherId { get; set; }
    public int ViceId { get; set; }
    public float NewGrade { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Remarks { get; set; }
    public DateOnly TestDate { get; set; }
    public bool Delayed { get; set; }
    public DateTime CreatedAt { get; set; }
}

