using Microsoft.AspNetCore.Components;
using Shared.DTOs.GradAdjustment;
using Shared.DTOs.Module;
using Shared.DTOs.Student;
using Web.Services.Interfaces;

namespace Web.Components;

/// <summary>
/// Handles mailbox grade requests
/// </summary>
public partial class MailboxComponent
{
    /// <summary>
    /// Gets or sets the grade service.
    /// </summary>
    [Inject] public required IGradeService _gradeS { get; set; }

    /// <summary>
    /// Gets or sets the student service.
    /// </summary>
    [Inject] public required IStudentService _studentS { get; set; }

    /// <summary>
    /// Gets or sets the module service.
    /// </summary>
    [Inject] public required IModuleService _moduleS { get; set; }

    /// <summary>
    /// Gets or sets the inbox grades.
    /// </summary>
    public List<GradeAdjustmentDto> inboxGrades { get; set; } = [];

    /// <summary>
    /// Gets or sets the students.
    /// </summary>
    public List<StudentListDto> students { get; set; } = [];

    /// <summary>
    /// Gets or sets the modules.
    /// </summary>
    public List<ModuleDto> modules { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        await LoadGrades();
    }

    /// <summary>
    /// Loads all grades, students and modules.
    /// </summary>
    /// <returns>A task.</returns>
    public async Task LoadGrades()
    {
        var allGrades = await _gradeS.GetAll() ?? new();
        students = await _studentS.GetAll() ?? new();
        modules = await _moduleS.GetAll() ?? new();

        inboxGrades = allGrades
            //.Where(g => g.Status == "Akzeptiert" || g.Status == "Abgelehnt")
            .ToList();
    }
}
