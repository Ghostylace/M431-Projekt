namespace Shared.DTOs.Auth;


public class LoginResponse
{

    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    public string Role { get; set; } = string.Empty;

    /// <summaryGets or sets the JWT token.
    /// </summary>
    public string JwtToken { get; set; } = string.Empty;
}
