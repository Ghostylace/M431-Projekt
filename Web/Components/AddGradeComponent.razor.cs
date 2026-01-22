using Microsoft.AspNetCore.Components;
using Shared.DTOs.GradAdjustment;
using Shared.DTOs.Module;
using Shared.DTOs.Prorektor;
using Shared.DTOs.Student;
using Shared.DTOs.Teacher;
using Web.Services;
using Web.Services.Interfaces;

namespace Web.Components;

/// <summary>
/// Handles adding a new grade request
/// </summary>
public partial class AddGradeComponent : ComponentBase
{
    /// <summary>
    /// Gets or sets the teacher service.
    /// </summary>
    [Inject]
    public required ITeacherService _teacherS { get; set; }

    /// <summary>
    /// Gets or sets the vice rectorate service.
    /// </summary>
    [Inject]
    public required IVice_RectorateService _viceS { get; set; }

    /// <summary>
    /// Gets or sets the student service.
    /// </summary>
    [Inject]
    public required IStudentService _studentS { get; set; }

    /// <summary>
    /// Gets or sets the module service.
    /// </summary>
    [Inject]
    public required IModuleService _moduleS { get; set; }

    /// <summary>
    /// Gets or sets the grade service.
    /// </summary>
    [Inject]
    public required IGradeService _gradeS { get; set; }

    /// <summary>
    /// Gets or sets the notification service.
    /// </summary>
    [Inject]
    public required NotificationService NotificationService { get; set; }

    /// <summary>
    /// Gets or sets the teachers.
    /// </summary>
    public List<TeacherDTO>? teachers { get; set; } = [];

    /// <summary>
    /// Gets or sets the vice rectorates.
    /// </summary>
    public List<ProrektorDTO>? vices { get; set; } = [];

    /// <summary>
    /// Gets or sets the students.
    /// </summary>
    public List<StudentListDto>? students { get; set; } = [];

    /// <summary>
    /// Gets or sets the modules.
    /// </summary>
    public List<ModuleDto>? modules { get; set; } = [];

    private List<GradeAdjustmentDto>? grades { get; set; } = [];
    private List<StudentRoundings> roundings { get; set; } = [];

    /// <summary>
    /// Gets or sets the details of the new grade to be created as part of the adjustment request.
    /// </summary>
    public CreateGradeAdjustmentRequest NewGrade { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        teachers = await _teacherS.GetAll();
        vices = await _viceS.GetAll();
        students = await _studentS.GetAll();
        modules = await _moduleS.GetAll();
        grades = await _gradeS.GetAll();
        roundings = [];
        foreach(StudentListDto student in students)
        {
            int roundedUp = 0;
            int roundedDown = 0;
            foreach(GradeAdjustmentDto grade in grades)
            {
                if (grade.RoundedUp && grade.StudentId == student.Id)
                    roundedUp++;
                else if(!grade.RoundedUp && grade.StudentId == student.Id)
                    roundedDown++;
            }
            roundings.Add(new()
            {
                StudentId = student.Id,
                RoundedUp = roundedUp,
                RoundedDown = roundedDown
            });
        }
    }

    private async Task AddGrade()
    {
        bool isSuccess = await _gradeS.AddGrade(NewGrade);
        Console.WriteLine(isSuccess);

        NotificationService.AddRequest();
    }
}
