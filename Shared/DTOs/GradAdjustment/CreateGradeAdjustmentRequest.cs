namespace Shared.DTOs.GradAdjustment;

public class CreateGradeAdjustmentRequest
{
    /// <summary>Gets or sets the teacher identifier.</summary>
    public int TeacherId { get; set; } = 1;

    /// <summary>Gets or sets the prorector identifier.</summary>
    public int ProrectorId { get; set; } = 1;

    /// <summary>Gets or sets the student identifier.</summary>
    public int StudentId { get; set; } = 1;

    /// <summary>Gets or sets the module identifier.</summary>
    public int ModuleId { get; set; } = 1;

    /// <summary>Creates new grade.</summary>
    public decimal NewGrade { get; set; }

    /// <summary>Gets or sets the remarks.</summary>
    public string? Remarks { get; set; }

    /// <summary>Gets or sets the test date.</summary>
    public DateTime TestDate { get; set; }

    /// <summary>Gets or sets a value indicating whether this <see cref="CreateGradeAdjustmentRequest" /> is delayed.</summary>
    public bool Delayed { get; set; }

    /// <summary>Gets or sets a value indicating whether [rounded up].</summary>
    public bool RoundedUp { get; set; }
}
