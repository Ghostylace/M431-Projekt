using API.Models;
using API.Services.Abstract;
using Shared.DTOs.Auth;
using Supabase;

namespace API.Services;

public class AuthService : IAuthService
{
    private readonly Client _supabase;

    public AuthService(Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        // 1️⃣ Teacher prüfen
        var teacherResponse = await _supabase
            .From<Teacher>()
            .Where(t => t.Email == request.Email)
            .Get();

        var teacher = teacherResponse.Models.FirstOrDefault();

        if (teacher != null)
        {
            if (!PasswordHasher.Verify(request.Password, teacher.PasswordHash))
                throw new UnauthorizedAccessException("Invalid password");

            return new LoginResponse
            {
                UserId = teacher.Id,
                Role = "teacher"
            };
        }

        // 2️⃣ Prorector prüfen
        var prorectorResponse = await _supabase
            .From<Prorector>()
            .Where(p => p.Email == request.Email)
            .Get();

        var prorector = prorectorResponse.Models.FirstOrDefault();

        if (prorector != null)
        {
            if (!PasswordHasher.Verify(request.Password, prorector.PasswordHash))
                throw new UnauthorizedAccessException("Invalid password");

            return new LoginResponse
            {
                UserId = prorector.Id,
                Role = "prorector"
            };
        }

        throw new UnauthorizedAccessException("User not found");
    }
    public async Task ChangePasswordAsync(ChangePasswordRequest request)
    {
        var response = await _supabase
            .From<Teacher>()
            .Where(x => x.Id == request.TeacherId)
            .Get();

        var teacher = response.Models.FirstOrDefault();

        if (teacher == null)
            throw new Exception("Teacher not found");

        if (!BCrypt.Net.BCrypt.Verify(request.OldPassword, teacher.PasswordHash))
            throw new Exception("Old password is incorrect");

        teacher.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        teacher.MustChangePassword = false;
        teacher.PasswordChangedAt = DateTime.UtcNow;

        await _supabase
            .From<Teacher>()
            .Update(teacher);
    }
}
