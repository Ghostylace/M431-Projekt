using API.Models;
using API.Services.Abstract;
using Shared.DTOs.GradAdjustment;
using Supabase;

namespace API.Services;

public class GradeAdjustmentService : IGradeAdjustmentService
{
    private readonly Client _supabase;

    public GradeAdjustmentService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<GradeAdjustment> CreateAsync(CreateGradeAdjustmentRequest request)
    {
        var entity = new GradeAdjustment
        {
            LehrpersonID = request.TeacherId,
            ProrektorID = request.ProrectorId,
            LernenderID = request.StudentId,
            ModulID = request.ModuleId,
            AlteNote = request.OldGrade,
            NeueNote = request.NewGrade,
            Bemerkungen = request.Remarks
        };

        var result = await _supabase
            .From<GradeAdjustment>()
            .Insert(entity);

        return result.Models.First();
    }

    public async Task<List<GradeAdjustment>> GetAllAsync()
    {
        var response = await _supabase
            .From<GradeAdjustment>()
            .Get();

        return response.Models;
    }

    public async Task UpdateStatusAsync(int id, UpdateGradeAdjustmentStatusRequest request)
    {
        var response = await _supabase
            .From<GradeAdjustment>()
            .Where(x => x.Id == id)
            .Get();

        var entity = response.Models.FirstOrDefault();
        if (entity == null)
            throw new KeyNotFoundException();

        entity.Status = request.Status;
        entity.Ablehnungsgrund = request.RejectionReason;
        entity.Pruefungsdatum = DateTime.UtcNow;

        await _supabase
            .From<GradeAdjustment>()
            .Update(entity);
    }
}

