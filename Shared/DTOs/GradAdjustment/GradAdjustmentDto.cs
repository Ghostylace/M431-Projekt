namespace Shared.DTOs.GradAdjustment;

public class GradeAdjustmentListDto
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public int ModuleId { get; set; }
    public int TeacherId { get; set; }
    public int ViceId { get; set; }

    public decimal NewGrade { get; set; }
    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}

