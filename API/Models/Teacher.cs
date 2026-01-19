using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models
{
    [Table("teacher")]
    public class Teacher : BaseModel
    {
        [PrimaryKey("teacherid")]
        public int Id { get; set; }

        [Column("lastname")]
        public string LastName { get; set; } = string.Empty;

        [Column("firstname")]
        public string FirstName { get; set; } = string.Empty;

        [Column("e_mail")]
        public string Email { get; set; } = null!;

        [Column("passwordHash")]
        public string PasswordHash { get; set; } = null!;

        [Column("salt")]
        public string Salt { get; set; } = string.Empty;
    }
}
