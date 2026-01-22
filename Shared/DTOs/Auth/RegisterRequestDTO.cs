namespace Shared.DTOs.Auth;

public class RegisterRequestDTO
{

    /// <summary>Gets or sets the name of the user.</summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>Gets or sets the email.</summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>Gets or sets the password.</summary>
    public string Password { get; set; } = string.Empty;
}
