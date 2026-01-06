using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models
{
    [Table("lehrperson")]
    public class Teacher : BaseModel
    {
        [PrimaryKey("lehrpersonid")]
        public int Id { get; set; }

        [Column("e_mail")]
        public string Email { get; set; } = null!;

        [Column("passwordhash")]
        public string PasswordHash { get; set; } = null!;

        [Column("mustchangepassword")]
        public bool MustChangePassword { get; set; }

        [Column("passwordchangedat")]
        public DateTime? PasswordChangedAt { get; set; }
        public string LastName { get; internal set; }
        public string FirstName { get; internal set; }
    }
}
