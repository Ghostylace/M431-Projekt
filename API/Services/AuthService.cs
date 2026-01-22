using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Supabase.Postgrest.Responses;
using System.Text;
using API.Models;
using API.Services.Abstract;
using Microsoft.IdentityModel.Tokens;
using Shared.DTOs.Auth;
using Supabase;

namespace API.Services;

public class AuthService : IAuthService
{
    private readonly Client _supabase;
    private readonly IConfiguration _config;

    public AuthService(Client supabase, IConfiguration config)
    {
        _supabase = supabase;
        _config = config;
    }

    /// <summary>
    /// The login method for the user to log in
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="UnauthorizedAccessException"></exception>
    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        // 1️⃣ Teacher prüfen
        ModeledResponse<Teacher> teacherResponse = await _supabase
            .From<Teacher>()
            .Where(t => t.Email == request.Email)
            .Get();

        Teacher? teacher = teacherResponse.Models.FirstOrDefault();

        if (teacher != null)
        {
            if (!PasswordHasher.Verify(request.Password, teacher.Salt, teacher.PasswordHash))
                throw new UnauthorizedAccessException("Invalid password");

            string jwtToken = GenerateJwtTokenTeacher(teacher);
            return new LoginResponse
            {
                UserId = teacher.Id,
                Role = "teacher",
                JwtToken = jwtToken
            };
        }

        //2️⃣ Prorector prüfen
        ModeledResponse<Prorector> prorectorResponse = await _supabase
            .From<Prorector>()
            .Where(p => p.Email == request.Email)
            .Get();

        Prorector? prorector = prorectorResponse.Models.FirstOrDefault();

        if (prorector != null)
        {
            if (!PasswordHasher.Verify(request.Password, prorector.Salt, prorector.PasswordHash))
                throw new UnauthorizedAccessException("Invalid password");

            string jwtToken = GenerateJwtTokenProrector(prorector);
            return new LoginResponse
            {
                UserId = prorector.Id,
                Role = "prorector",
                JwtToken = jwtToken
            };
        }

        throw new UnauthorizedAccessException("User not found");
    }
    /// <summary>
    /// The changepasswordasync method for the user to change their password
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task ChangePasswordAsync(ChangePasswordRequest request)
    {
        ModeledResponse<Teacher> response = await _supabase
            .From<Teacher>()
            .Where(x => x.Id == request.TeacherId)
            .Get();

        Teacher? teacher = response.Models.FirstOrDefault();

        if (teacher == null)
            throw new Exception("Teacher not found");

        if (!BCrypt.Net.BCrypt.Verify(request.OldPassword, teacher.PasswordHash))
            throw new Exception("Old password is incorrect");

        teacher.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

        await _supabase
            .From<Teacher>()
            .Update(teacher);
    }

    private string GenerateJwtTokenTeacher(Teacher user)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        byte[] key = Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? "a");

        Claim[] claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Name, $"{user.FirstName} {user.LastName}")
        };

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(3),
            Issuer = _config["Jwt:Issuer"],
            Audience = _config["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
                )
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private string GenerateJwtTokenProrector(Prorector user)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        byte[] key = Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? "a");

        Claim[] claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Name, $"{user.Firstname} {user.Lastname}")
        };

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(3),
            Issuer = _config["Jwt:Issuer"],
            Audience = _config["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
                )
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
