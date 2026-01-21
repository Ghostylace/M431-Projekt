using Microsoft.AspNetCore.Components;
using Shared.DTOs.GradAdjustment;
using Shared.DTOs.Student;
using Shared.DTOs.Teacher;
using Web.Services.Interfaces;

namespace Web.Components;

/// <summary>
/// Handles grade requests for the prorector
/// </summary>
public partial class GradeRequestProrektorComponent
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
    /// Gets or sets the teacher service.
    /// </summary>
    [Inject] public required ITeacherService _teacherS { get; set; }

    /// <summary>
    /// Gets or sets the delayed grades.
    /// </summary>
    public List<GradeAdjustmentDto> delayedGrades { get; set; } = [];

    /// <summary>
    /// Gets or sets the students.
    /// </summary>
    public List<StudentListDto> students { get; set; } = [];

    /// <summary>
    /// Gets or sets the teachers.
    /// </summary>
    public List<TeacherDTO> teachers { get; set; } = [];

    /// <summary>
    /// Gets or sets the selected grade.
    /// </summary>
    GradeAdjustmentDto? selectedGrade;

    /// <summary>
    /// Gets or sets the remark text.
    /// </summary>
    string remarkText = "";

    /// <summary>
    /// Called when the component is initialized.
    /// </summary>
    /// <returns>A task.</returns>
    protected override async Task OnInitializedAsync()
    {
        var allGrades = await _gradeS.GetAll() ?? new();
        students = await _studentS.GetAll() ?? new();
        teachers = await _teacherS.GetAll() ?? new();   

        delayedGrades = allGrades
            .Where(g => g.Delayed == false)
            .ToList();

        NotificationService.ClearRequests();
    }

    /// <summary>
    /// Opens the modal for a grade request.
    /// </summary>
    /// <param name="grade">The grade.</param>
    void OpenModal(GradeAdjustmentDto grade)
    {
        selectedGrade = grade;
        remarkText = "";
    }

    /// <summary>
    /// Closes the modal.
    /// </summary>
    void CloseModal()
    {
        selectedGrade = null;
    }

    /// <summary>
    /// Accepts the selected grade request.
    /// </summary>
    /// <returns>A task.</returns>
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

    /// <summary>
    /// Rejects the selected grade request.
    /// </summary>
    /// <returns>A task.</returns>
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
