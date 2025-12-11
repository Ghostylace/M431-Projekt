using Shared.DTOs;
using Supabase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Services;

    public class NotenanpassungService
    {
        private readonly Client _supabase;

        public NotenanpassungService(Client supabase)
        {
            _supabase = supabase;
        }

        // Antrag erstellen
        public async Task<GradadjustmentDto> CreateAsync(CreateAntragRequest req)
        {
            var antrag = new NotenanpassungAntrag
            {
                LehrpersonID = req.LehrpersonID,
                ProrektorID = req.ProrektorID,
                LernenderID = req.LernenderID,
                ModulID = req.ModulID,
                AlteNote = req.AlteNote,
                NeueNote = req.NeueNote,
                Bemerkungen = req.Bemerkungen,
                Status = "EINGEREICHT",
                Antragsdatum = DateTime.UtcNow
            };

            var result = await _supabase
                .From<NotenanpassungAntrag>()
                .Insert(antrag);

            return result.Models.First();
        }

        // Alle Anträge holen
        public async Task<List<NotenanpassungAntrag>> GetAllAsync()
        {
            var response = await _supabase
                .From<NotenanpassungAntrag>()
                .Select("*")
                .Get();

            return response.Models;
        }

        // Status aktualisieren
        public async Task UpdateStatusAsync(int antragId, string newStatus, string? grund = null)
        {
            var values = new Dictionary<string, object?>
        {
            { "Status", newStatus },
            { "Ablehnungsgrund", grund }
        };

            await _supabase
                .From<NotenanpassungAntrag>()
                .Where(a => a.AntragID == antragId)
                .Update(values);
        }
    }

