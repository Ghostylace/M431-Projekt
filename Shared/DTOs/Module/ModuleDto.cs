namespace Shared.DTOs.Module
{
    public class ModuleDto
    {

        /// <summary>Gets or sets the identifier.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Gets or sets the semester.</summary>
        public int Semester { get; set; }
    }

}
