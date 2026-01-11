using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("module")]
public class Module : BaseModel
{
    [PrimaryKey("ModuleId")]
    public int Id { get; set; }
    [Column("Modulname")]
    public string Modulname { get; set; } = string.Empty;
    [Column("Semester")]
    public int Semester { get; set; }
}


