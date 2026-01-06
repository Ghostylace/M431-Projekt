namespace Shared.DTOs.Auth;

public class ChangePasswordRequest
{
    public int TeacherId { get; set; }
    public string OldPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}
