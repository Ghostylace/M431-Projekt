using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("module")]
public class Module : BaseModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the module.
    /// </summary>
    [PrimaryKey("moduleid")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the module associated with this entity.
    /// </summary>
    [Column("modulname")]
    public string Modulname { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the academic semester associated with the entity.
    /// </summary>
    [Column("semester")]
    public int Semester { get; set; }
}


