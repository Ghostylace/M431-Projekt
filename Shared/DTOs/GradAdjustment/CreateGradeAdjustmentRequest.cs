namespace Shared.DTOs.GradAdjustment;

public class CreateGradeAdjustmentRequest
{
    public int TeacherId { get; set; } = 1;
    public int ProrectorId { get; set; } = 1;
    public int StudentId { get; set; } = 1;
    public int ModuleId { get; set; } = 1;
    public float NewGrade { get; set; }
    public string? Remarks { get; set; }
    public DateOnly TestDate { get; set; }
    public bool Delayed { get; set; }
}
