using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("modul")]
public class Module : BaseModel
{
    [PrimaryKey("ModulID")]
    public int Id { get; set; }

    public string Modulname { get; set; } = string.Empty;
    public int Semester { get; set; }
}


