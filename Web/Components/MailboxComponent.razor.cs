using Microsoft.AspNetCore.Components;
using Shared.DTOs.GradAdjustment;
using Shared.DTOs.Module;
using Shared.DTOs.Student;
using Web.Pages;
using Web.Services.Interfaces;

namespace Web.Components;
public partial class MailboxComponent
{
    [Inject] public required IGradeService _gradeS { get; set; }
    [Inject] public required IStudentService _studentS { get; set; }
    [Inject] public required IModuleService _moduleS { get; set; }

    public List<GradeAdjustmentDto> inboxGrades { get; set; } = [];
    public List<StudentListDto> students { get; set; } = [];
    public List<ModuleDto> modules { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        var allGrades = await _gradeS.GetAll() ?? new List<GradeAdjustmentDto>();

        students = await _studentS.GetAll() ?? new List<StudentListDto>();
        modules = await _moduleS.GetAll() ?? new List<ModuleDto>();

        inboxGrades = allGrades
            .Where(g => g.Status == "Akzeptiert" || g.Status == "Abgelehnt")
            .ToList();
    }

}
