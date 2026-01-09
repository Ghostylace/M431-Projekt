using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("prorektorat")]
public class Prorector : BaseModel
{
    [PrimaryKey("ProrektorID")]
    public int Id { get; set; }

    [Column("Firstname")]
    public string Firstname { get; set; } = string.Empty;

    [Column("Lastname")]
    public string Lastname{ get; set; } = string.Empty;

    [Column("E_Mail")]
    public string Email { get; set; } = string.Empty;

    [Column("Passwordhash")]
    public string PasswordHash { get; set; } = string.Empty;

}

