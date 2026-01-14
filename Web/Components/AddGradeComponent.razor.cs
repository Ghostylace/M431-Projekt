using Microsoft.AspNetCore.Components;
using Shared.DTOs.GradAdjustment;
using Shared.DTOs.Module;
using Shared.DTOs.Prorektor;
using Shared.DTOs.Student;
using Shared.DTOs.Teacher;
using Web.Services.Interfaces;

namespace Web.Components;
public partial class AddGradeComponent : ComponentBase
{
    [Inject]
    public required ITeacherService _teacherS { get; set; }
    [Inject]
    public required IVice_RectorateService _viceS { get; set; }
    [Inject]
    public required IStudentService _studentS { get; set; }
    [Inject]
    public required IModuleService _moduleS { get; set; }

    public List<TeacherDTO>? teachers { get; set; } = [];
    public List<ProrektorDTO>? vices { get; set; } = [];
    public List<StudentListDto>? students { get; set; } = [];
    public List<ModuleDto>? modules { get; set; } = [];

    public GradeAdjustmentListDto NewGrade { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        teachers = await _teacherS.GetAll();
        vices = await _viceS.GetAll();
        students = await _studentS.GetAll();
        modules = await _moduleS.GetAll();
    }
}
