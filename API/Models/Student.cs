using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("student")]
public class Student : BaseModel
{
    [PrimaryKey("studentid")]
    public int Id { get; set; }
    [Column("firstname")]
    public string Vorname { get; set; } = string.Empty;
    [Column("lastname")]
    public string Nachname { get; set; } = string.Empty;
    [Column("e_mail")]
    public string E_Mail { get; set; } = string.Empty;
    [Column("class")]
    public string Klasse { get; set; } = string.Empty;
}
