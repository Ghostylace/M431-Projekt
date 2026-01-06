using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("notenanpassung_antrag")]
public class GradeAdjustment : BaseModel
{
    [PrimaryKey("AntragID")]
    public int Id { get; set; }

    public int LehrpersonID { get; set; }
    public int ProrektorID { get; set; }
    public int LernenderID { get; set; }
    public int ModulID { get; set; }

    public decimal? AlteNote { get; set; }
    public decimal NeueNote { get; set; }

    public DateTime Antragsdatum { get; set; }
    public string? Bemerkungen { get; set; }

    public string Status { get; set; } = "EINGEREICHT";
    public DateTime? Pruefungsdatum { get; set; }
    public string? Ablehnungsgrund { get; set; }
}

