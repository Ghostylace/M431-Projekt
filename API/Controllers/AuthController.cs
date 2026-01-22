using API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Auth;

namespace API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    /// <summary>
    /// Constructor for DI
    /// </summary>
    /// <param name="authService">Parameter for DI</param>
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Authenticates a user based on the provided login credentials.
    /// </summary>
    /// <param name="request">An object containing the user's login credentials. Cannot be null.</param>
    /// <returns>An HTTP 200 response with authentication details if the login is successful; otherwise, an HTTP 401 response if
    /// authentication fails.</returns>

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        try
        {
            return Ok(await _authService.LoginAsync(request));
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    /// <summary>
    /// Changes the password for the current authenticated user.
    /// </summary>
    /// <remarks>This endpoint requires the user to be authenticated. The request must include valid current
    /// and new password values as defined by the ChangePasswordRequest model. If the password change fails due to
    /// invalid credentials or policy violations, an appropriate error response is returned.</remarks>
    /// <param name="request">An object containing the current and new password information required to perform the password change. Cannot be
    /// null.</param>
    /// <returns>An IActionResult indicating the result of the password change operation. Returns a success message if the
    /// password was changed successfully.</returns>
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        await _authService.ChangePasswordAsync(request);
        return Ok(new { message = "Password changed successfully" });
    }
}
