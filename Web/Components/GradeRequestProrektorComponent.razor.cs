using Microsoft.AspNetCore.Components;
using Shared.DTOs.GradAdjustment;
using Shared.DTOs.Student;
using Shared.DTOs.Teacher;
using Web.Services.Interfaces;

namespace Web.Components;
public partial class GradeRequestProrektorComponent
{

    [Inject] public required IGradeService _gradeS { get; set; }
    [Inject] public required IStudentService _studentS { get; set; }
    [Inject] public required ITeacherService _teacherS { get; set; }

    public List<GradeAdjustmentDto> delayedGrades { get; set; } = [];
    public List<StudentListDto> students { get; set; } = [];
    public List<TeacherDTO> teachers { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        var allGrades = await _gradeS.GetAll();
        students = await _studentS.GetAll();
        teachers = await _teacherS.GetAll();

        delayedGrades = allGrades!
            .Where(g => g.Delayed == false)
            .ToList();
    }
}
