using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("student")]
public class Student : BaseModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the student.
    /// </summary>
    [PrimaryKey("studentid")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of the person.
    /// </summary>
    [Column("firstname")]
    public string Vorname { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name of the person.
    /// </summary>
    [Column("lastname")]
    public string Nachname { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address associated with the entity.
    /// </summary>
    [Column("e_mail")]
    public string E_Mail { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the class designation associated with the entity.
    /// </summary>
    [Column("class")]
    public string Klasse { get; set; } = string.Empty;
}
