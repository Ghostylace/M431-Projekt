using Shared.DTOs.Auth;

namespace Web.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest loginRequestDTO);
    }
}
