namespace Shared.DTOs.GradAdjustment;

public class CreateGradeAdjustmentRequest
{
    public int TeacherId { get; set; }
    public int ProrectorId { get; set; }
    public int StudentId { get; set; }
    public int ModuleId { get; set; }
    public float NewGrade { get; set; }
    public string? Remarks { get; set; }
    public DateOnly TestDate { get; set; }
    public bool Delayed { get; set; }
}
