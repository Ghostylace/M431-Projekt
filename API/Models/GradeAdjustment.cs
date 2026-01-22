using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("gradadjustment")]
public class GradeAdjustment : BaseModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    [PrimaryKey("antragid")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the teacher.
    /// </summary>
    [Column("teacherid")]
    public int TeacherId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the associated vice rectorate.
    /// </summary>
    [Column("vise_rectorateid")]
    public int Vise_RectorateId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the student.
    /// </summary>
    [Column("studentid")]
    public int StudentId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the module.
    /// </summary>
    [Column("moduleid")]
    public int ModuleId { get; set; }

    /// <summary>
    /// Gets or sets the new grade value associated with the entity.
    /// </summary>
    [Column("newgrad")]
    public decimal NewGrade { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    [Column("creationdate")]
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Gets or sets the description associated with the entity.
    /// </summary>
    [Column("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the item is delayed.
    /// </summary>
    [Column("delayed")]
    public bool IsDelayed { get; set; }

    /// <summary>
    /// Gets or sets the current status of the entity.
    /// </summary>
    [Column("status")]
    public string Status { get; set; } = "EINGEREICHT";

    /// <summary>
    /// Gets or sets the date associated with the test, if available.
    /// </summary>
    [Column("testdate")]
    public DateTime? TestDate { get; set; }

    /// <summary>
    /// Gets or sets the reason provided for rejecting the item or request.
    /// </summary>
    [Column("rejectionreason")]
    public string? RejectionReason { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the value was rounded up during calculation.
    /// </summary>
    [Column("RoundedUp")]
    public bool RoundedUp { get; set; }
}

