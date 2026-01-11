using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models
{
    [Table("Teacher")]
    public class Teacher : BaseModel
    {
        [PrimaryKey("TeacherId")]
        public int Id { get; set; }

        [Column("Firstname")]
        public string LastName { get; set; } = string.Empty;
        [Column("Lastname")]
        public string FirstName { get; set; } = string.Empty;
        [Column("E_Mail")]
        public string Email { get; set; } = null!;

        [Column("PasswordHash")]
        public string PasswordHash { get; set; } = null!;
    }
}
