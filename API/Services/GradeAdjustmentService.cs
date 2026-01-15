using API.Models;
using API.Services.Abstract;
using Shared.DTOs.GradAdjustment;
using Supabase.Postgrest.Responses;
using Supabase;

namespace API.Services;

public class GradeAdjustmentService : IGradeAdjustmentService
{
    private readonly Client _supabase;

    public GradeAdjustmentService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<GradeAdjustmentDto> CreateAsync(CreateGradeAdjustmentRequest request)
    {
        GradeAdjustment entity = new GradeAdjustment
        {
            TeacherId = request.TeacherId,
            Vise_RectorateId = request.ProrectorId,
            StudentId = request.StudentId,
            ModuleId = request.ModuleId,
            NewGrad = request.NewGrade,
            Description = request.Remarks,
            IsDelayed = request.Delayed,
            TestDate = request.TestDate
        };

        ModeledResponse<GradeAdjustment> result = await _supabase
            .From<GradeAdjustment>()
            .Insert(entity);

        GradeAdjustment resp = result.Models.First();
        return new GradeAdjustmentDto()
        {
            Id = resp.Id,
            TeacherId = resp.TeacherId,
            StudentId = resp.StudentId,
            ViceId = resp.Vise_RectorateId,
            ModuleId = resp.ModuleId,
            CreatedAt = resp.CreationDate,
            NewGrade = resp.NewGrad,
            Remarks = resp.Description ?? string.Empty,
            Delayed = resp.IsDelayed,
            Status = resp.Status,
            TestDate = resp.TestDate
        };
    }

    public async Task<List<GradeAdjustmentDto>> GetAllAsync()
    {
        ModeledResponse<GradeAdjustment> response = await _supabase
            .From<GradeAdjustment>()
            .Get();

        List<GradeAdjustment> resp = response.Models;
        List<GradeAdjustmentDto> toReturn = [];

        foreach(GradeAdjustment res in resp)
        {
            toReturn.Add(new GradeAdjustmentDto()
            {
                Id = res.Id,
                TeacherId = res.TeacherId,
                StudentId = res.StudentId,
                ViceId = res.Vise_RectorateId,
                ModuleId = res.ModuleId,
                CreatedAt = res.CreationDate,
                NewGrade = res.NewGrad,
                Remarks = res.Description ?? string.Empty,
                Delayed = res.IsDelayed,
                Status = res.Status,
                TestDate = res.TestDate
            });
        }

        return toReturn;
    }

    public async Task<bool> UpdateStatusAsync(int id, UpdateGradeAdjustmentStatusRequest request)
    {
        ModeledResponse<GradeAdjustment> response = await _supabase
            .From<GradeAdjustment>()
            .Where(x => x.Id == id)
            .Get();

        GradeAdjustment? entity = response.Models.FirstOrDefault();
        if (entity == null)
            throw new KeyNotFoundException();

        entity.Status = request.Status;
        entity.RejectionReason = request.RejectionReason;
        entity.TestDate = DateOnly.FromDateTime(DateTime.UtcNow);

        ModeledResponse<GradeAdjustment> resp = await _supabase
            .From<GradeAdjustment>()
            .Update(entity);
        return resp.ResponseMessage.IsSuccessStatusCode;
    }
}

