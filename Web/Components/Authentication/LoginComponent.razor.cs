using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Shared.DTOs.Auth;
using Web.Services.Interfaces;

namespace Web.Components.Authentication;

/// <summary>
/// Handles user login
/// </summary>
public partial class LoginComponent : ComponentBase
{
    /// <summary>
    /// Gets or sets the authentication service.
    /// </summary>
    [Inject]
    public required IAuthService _authService { get; set; }

    [Inject]
    public required HttpClient Http { get; set; }

    [Inject]
    public required NavigationManager navManager { get; set; }
    private string Email { get; set; } = string.Empty;
    private string Password { get; set; } = string.Empty;
    private int randomCode = 10000;
    private int randomCodeUser { get; set; }
    private Random rnd = new();
    private async Task LoginButton()
    {
        
        LoginRequest user = new()
        {
            Email = Email,
            Password = Password
        };

        LoginResponse? resp = await _authService.LoginAsync(user);

        if (resp == null)
        {
            Console.WriteLine("Something went wrong");
        }
        else
        {
            Console.WriteLine(resp.UserId);
            Console.WriteLine(resp.JwtToken);
        }

        randomCode = rnd.Next(10000, 99999);

        EmailRequest email = new EmailRequest()
        {
            To = "daguy6767@gmail.com",
            Subject = "Ihr Zwei-Faktor Code",
            Body = $"{randomCode}"
        };

        await Http.PostAsJsonAsync("api/email", email);
    }

    private async Task CheckRandomCode()
    {
        if(randomCodeUser == randomCode)
        {
            Console.WriteLine("You entered the correct code");
            Email = string.Empty;
            Password = string.Empty;
            navManager.NavigateTo("/Grades");
        }
        else
        {
            Console.WriteLine("You entered the wrong code");
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}
