using System.ComponentModel.DataAnnotations.Schema;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace Shared.DTOs;
public class CreateAntragRequest
    {
        public int LehrpersonID { get; set; }
        public int ProrektorID { get; set; }
        public int LernenderID { get; set; }
        public int ModulID { get; set; }

        public decimal? AlteNote { get; set; }
        public decimal NeueNote { get; set; }
        public string? Bemerkungen { get; set; }
}


