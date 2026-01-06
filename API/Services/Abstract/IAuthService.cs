using Shared.DTOs.Auth;

namespace API.Services.Abstract;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task ChangePasswordAsync(ChangePasswordRequest request);
}
