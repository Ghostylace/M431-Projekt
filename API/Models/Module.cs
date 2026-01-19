using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("module")]
public class Module : BaseModel
{
    [PrimaryKey("moduleid")]
    public int Id { get; set; }
    [Column("modulname")]
    public string Modulname { get; set; } = string.Empty;
    [Column("semester")]
    public int Semester { get; set; }
}


