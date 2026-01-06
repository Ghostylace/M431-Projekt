using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("lernender")]
public class Student : BaseModel
{
    [PrimaryKey("LernenderID")]
    public int Id { get; set; }

    public string Vorname { get; set; } = string.Empty;
    public string Nachname { get; set; } = string.Empty;
    public string Klasse { get; set; } = string.Empty;
}
