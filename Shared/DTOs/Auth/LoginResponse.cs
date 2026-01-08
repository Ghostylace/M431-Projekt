namespace Shared.DTOs.Auth;

public class LoginResponse
{
    public int UserId { get; set; }
    public string Role { get; set; } = string.Empty;
}
