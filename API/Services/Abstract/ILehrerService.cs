using Shared.DTOs;

namespace API.Services.Abstract;

public interface ITeacherService
{
    Task<List<LookupDto>> GetAllAsync();
}
