using API.Models;
using API.Services.Abstract;
using Shared.DTOs;
using Supabase;

namespace API.Services;

public class ProrectorService : IProrectorService
{
    private readonly Client _supabase;

    public ProrectorService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<LookupDto>> GetAllAsync()
    {
        var response = await _supabase
            .From<Prorector>()
            .Get();

        return response.Models
            .Select(p => new LookupDto
            {
                Id = p.Id,
                DisplayName = $"{p.Firstname} {p.Lastname}"
            })
            .OrderBy(x => x.DisplayName)
            .ToList();
    }
}
