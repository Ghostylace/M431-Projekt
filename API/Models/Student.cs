using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("Student")]
public class Student : BaseModel
{
    [PrimaryKey("StudentId")]
    public int Id { get; set; }
    [Column("Firstname")]
    public string Vorname { get; set; } = string.Empty;
    [Column("Lastname ")]
    public string Nachname { get; set; } = string.Empty;
    [Column("E_Mail")]
    public string E_Mail { get; set; } = string.Empty;
    [Column("Class")]
    public string Klasse { get; set; } = string.Empty;
}
