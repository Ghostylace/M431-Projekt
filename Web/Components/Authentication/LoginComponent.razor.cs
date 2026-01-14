using Microsoft.AspNetCore.Components;
using Shared.DTOs.Auth;
using Web.Services.Interfaces;

namespace Web.Components.Authentication;
public partial class LoginComponent : ComponentBase
{
    [Inject]
    public required IAuthService _authService { get; set; }

    private string Email { get; set; } = string.Empty;
    private string Password { get; set; } = string.Empty;

    private async Task LoginButton()
    {
        LoginRequest user = new()
        {
            Email = Email,
            Password = Password
        };

        LoginResponse? resp = await _authService.LoginAsync(user);

        if(resp == null)
        {
            Console.WriteLine("Something went wrong");
        }
        else
        {
            Console.WriteLine(resp.UserId);
        }
    }
}
