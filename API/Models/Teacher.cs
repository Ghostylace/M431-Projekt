using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace API.Models
{
    [Table("teacher")]
    public class Teacher : BaseModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the teacher.
        /// </summary>
        [PrimaryKey("teacherid")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        [Column("lastname")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the first name of the person.
        /// </summary>
        [Column("firstname")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email of the person
        /// </summary>
        [Column("e_mail")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Gets or sets the password hash of the person
        /// </summary>
        [Column("passwordHash")]
        public string PasswordHash { get; set; } = null!;

        /// <summary>
        /// Gets or sets the salt of the person
        /// </summary>
        [Column("salt")]
        public string Salt { get; set; } = string.Empty;
    }
}
