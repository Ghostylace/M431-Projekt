using Shared.DTOs.Auth;

namespace Web.Services.Interfaces
{
    /// <summary>
    /// Interface containing methods for Authentication
    /// </summary>
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest loginRequestDTO);
    }
}
