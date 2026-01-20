using API.Models;
using API.Services.Abstract;
using Shared.DTOs.GradAdjustment;
using Supabase.Postgrest.Responses;
using Supabase;
using Azure;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

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
            NewGrade = request.NewGrade,
            Description = request.Remarks,
            IsDelayed = request.Delayed,
            TestDate = request.TestDate,
            CreationDate = DateTime.UtcNow,
            RoundedUp = request.RoundedUp
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
            NewGrade = resp.NewGrade,
            Remarks = resp.Description ?? string.Empty,
            Delayed = resp.IsDelayed,
            Status = resp.Status,
            TestDate = resp.TestDate,
            RoundedUp = resp.RoundedUp
        };
    }

    public async Task<List<GradeAdjustmentDto>> GetAllAsync()
    {
        ModeledResponse<GradeAdjustment> response = await _supabase
            .From<GradeAdjustment>()
            .Get();

        List<GradeAdjustment> resp = response.Models;
        List<GradeAdjustmentDto> toReturn = [];

        foreach (GradeAdjustment res in resp)
        {
            toReturn.Add(new GradeAdjustmentDto()
            {
                Id = res.Id,
                TeacherId = res.TeacherId,
                StudentId = res.StudentId,
                ViceId = res.Vise_RectorateId,
                ModuleId = res.ModuleId,
                CreatedAt = res.CreationDate,
                NewGrade = res.NewGrade,
                Remarks = res.Description ?? string.Empty,
                Delayed = res.IsDelayed,
                Status = res.Status,
                TestDate = res.TestDate,
                RoundedUp = res.RoundedUp
            });
        }

        return toReturn;
    }

    public async Task<bool> UpdateStatusAsync(int id, UpdateGradeAdjustmentStatusRequest request)
    {
        ModeledResponse<GradeAdjustment> res = await _supabase
            .From<GradeAdjustment>()
            .Where(x => x.Id == id)
            .Get();

        GradeAdjustment? existing = res.Models.FirstOrDefault();
        if (existing == null)
            return false;

        existing.Status = request.Status;
        existing.RejectionReason = request.DecisionRemark;
        existing.TestDate = DateTime.UtcNow;

        ModeledResponse<GradeAdjustment> updateResponse = await _supabase.From<GradeAdjustment>().Update(existing);

        return updateResponse.ResponseMessage.IsSuccessStatusCode;
    }

}

