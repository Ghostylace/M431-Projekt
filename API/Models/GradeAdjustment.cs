using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("gradadjustment")]
public class GradeAdjustment : BaseModel
{
    [PrimaryKey("antragid")]
    public int Id { get; set; }

    [Column("teacherid")]
    public int TeacherId { get; set; }

    [Column("vise_rectorateid")]
    public int Vise_RectorateId { get; set; }

    [Column("studentid")]
    public int StudentId { get; set; }

    [Column("moduleid")]
    public int ModuleId { get; set; }

    [Column("NewGrad")]
    public float NewGrad { get; set; }

    [Column("creationdate")]
    public DateTime CreationDate { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("delayed")]
    public bool IsDelayed { get; set; }

    [Column("status")]
    public string Status { get; set; } = "EINGEREICHT";

    [Column("testdate")]
    public DateTime? TestDate { get; set; }

    [Column("rejectionreason")]
    public string? RejectionReason { get; set; }
}

