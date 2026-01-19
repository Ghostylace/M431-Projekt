using Shared.DTOs.Prorektor;

namespace Web.Services.Interfaces
{
    /// <summary>
    /// Interface containing operations for prorector. 
    /// </summary>
    public interface IVice_RectorateService
    {
        /// <summary>
        /// Gets all prorectors. 
        /// </summary>
        /// <returns>Returns all prorectors. </returns>
        Task<List<ProrektorDTO>?> GetAll();
    }
}