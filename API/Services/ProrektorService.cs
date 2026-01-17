using API.Models;
using API.Services.Abstract;
using Shared.DTOs.Prorektor;
using Supabase.Postgrest.Responses;
using Supabase;

namespace API.Services;

public class ProrectorService : IProrectorService
{
    private readonly Client _supabase;

    public ProrectorService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<ProrektorDTO>> GetAllAsync()
    {
        ModeledResponse<Prorector> response = await _supabase
            .From<Prorector>()
            .Get();

        return response.Models
            .Select(p => new ProrektorDTO
            {
                Id = p.Id,
                Vorname = p.Firstname,
                Nachname = p.Lastname
            })
            .OrderBy(x => x.Vorname)
            .ToList();
    }
}
