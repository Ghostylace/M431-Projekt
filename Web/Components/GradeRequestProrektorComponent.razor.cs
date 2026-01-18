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

    GradeAdjustmentDto? selectedGrade;
    string remarkText = "";

    protected override async Task OnInitializedAsync()
    {
        var allGrades = await _gradeS.GetAll() ?? new();
        students = await _studentS.GetAll() ?? new();
        teachers = await _teacherS.GetAll() ?? new();

       
        delayedGrades = allGrades
            .Where(g => g.Delayed == false)
            .ToList();

    }

    void OpenModal(GradeAdjustmentDto grade)
    {
        selectedGrade = grade;
        remarkText = "";
    }

    void CloseModal()
    {
        selectedGrade = null;
    }

    async Task Accept()
    {
        if (selectedGrade == null) return;

        var req = new UpdateGradeAdjustmentStatusRequest
        {
            Id = selectedGrade.Id,
            Status = "Akzeptiert",
            DecisionRemark = remarkText
        };

        bool success = await _gradeS.UpdateStatus(req);
        if (success)
        {
            delayedGrades = delayedGrades.Where(g => g.Id != selectedGrade.Id).ToList();
            CloseModal();
            StateHasChanged();
        }
    }

    async Task Reject()
    {
        if (selectedGrade == null) return;

        var req = new UpdateGradeAdjustmentStatusRequest
        {
            Id = selectedGrade.Id,
            Status = "Abgelehnt",
            DecisionRemark = remarkText
        };

        bool success = await _gradeS.UpdateStatus(req);
        if (success)
        {
            delayedGrades = delayedGrades.Where(g => g.Id != selectedGrade.Id).ToList();
            CloseModal();
            StateHasChanged();
        }
    }

}
