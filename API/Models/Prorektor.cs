using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models;

[Table("vice_rectorate")]
public class Prorector : BaseModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the vice rectorate.
    /// </summary>
    [PrimaryKey("vice_rectorateid")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of the person.
    /// </summary>
    [Column("firstname")]
    public string Firstname { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name of the person.
    /// </summary>
    [Column("lastname")]
    public string Lastname{ get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address associated with the entity.
    /// </summary>
    [Column("e_mail")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the hashed representation of the user's password.
    /// </summary>
    [Column("passwordhash")]
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the cryptographic salt value used for password hashing or encryption operations.
    /// </summary>
    /// <remarks>The salt should be a unique, randomly generated string for each user or operation to enhance
    /// security and prevent precomputed attacks such as rainbow tables.</remarks>
    [Column("salt")]
    public string Salt { get; set; } = string.Empty;

}

