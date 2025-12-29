using System.Threading.Tasks;
using API.Models;
using API.Services.Abstract;
using Shared.DTOs.Prorektor;
using Supabase;

namespace API.Services;

public class ProrektorService : IProrektorService
{
    private readonly Client _supabase;

    public ProrektorService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<ProrektorDTO>?> GetAll()
    {
        var response = await _supabase.From<Prorektor>().Get();

        if (response.ResponseMessage.IsSuccessStatusCode)
        {
            List<ProrektorDTO> outList = await ConvertList(response.Models);
            return outList;
        }
        else
        {
            return null;
        }
    }

    private async Task<List<ProrektorDTO>> ConvertList(List<Prorektor> input)
    {
        List<ProrektorDTO> outList = [];

        foreach(var p in input)
        {
            outList.Add(new ProrektorDTO()
            {
                Id = p.Id,
                Vorname = p.Vorname,
                Nachname = p.Nachname,
                Email = p.Email
            });
        }

        return outList;
    }
}
