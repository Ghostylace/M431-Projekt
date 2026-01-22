namespace Shared.DTOs.Student
{
    public class StudentListDto
    {

        /// <summary>Gets or sets the identifier.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the full name.</summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>Gets or sets the klasse.</summary>
        public string Klasse { get; set; } = string.Empty;
    }

}
