using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("GradAdjustment")]
public class GradeAdjustment : BaseModel
{
    [PrimaryKey("AntragID")]
    public int Id { get; set; }

    [Column("TeacherId")]
    public int TeacherId { get; set; }

    [Column("Vise_RectorateId")]
    public int Vise_RectorateId { get; set; }

    [Column("StudentId")]
    public int StudentId { get; set; }

    [Column("ModuleId")]
    public int ModuleId { get; set; }

    [Column("Grade")]
    public decimal? AlteNote { get; set; }

    [Column("NeueNote")]
    public decimal NeueNote { get; set; }

    [Column("CreationDate")]
    public DateTime Antragsdatum { get; set; }

    [Column("Description")]
    public string? Description { get; set; }

    [Column("Delayed")]
    public bool IsDelayed { get; set; }

    [Column("Status")]
    public string Status { get; set; } = "EINGEREICHT";

    [Column("Testdate")]
    public DateTime? Testdate { get; set; }

    [Column("RejectionReason")]
    public string? RejectionReason { get; set; }
}

