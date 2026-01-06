namespace Shared.DTOs.GradAdjustment;

public class GradeAdjustmentListDto
{
    public int Id { get; set; }

    public string StudentName { get; set; } = string.Empty;
    public string ModuleName { get; set; } = string.Empty;

    public decimal NewGrade { get; set; }
    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}

