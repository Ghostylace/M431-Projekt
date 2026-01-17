using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("vice_rectorate")]
public class Prorector : BaseModel
{
    [PrimaryKey("vice_rectorateid")]
    public int Id { get; set; }

    [Column("firstname")]
    public string Firstname { get; set; } = string.Empty;

    [Column("lastname")]
    public string Lastname{ get; set; } = string.Empty;

    [Column("e_mail")]
    public string Email { get; set; } = string.Empty;

    [Column("passwordhash")]
    public string PasswordHash { get; set; } = string.Empty;
    [Column("salt")]
    public string Salt { get; set; } = string.Empty;

}

