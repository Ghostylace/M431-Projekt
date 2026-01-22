namespace Shared.DTOs.Auth;

public class ChangePasswordRequest
{

    /// <summary>
    /// Gets or sets the teacher identifier.
    /// </summary>
    public int TeacherId { get; set; }


    /// <summary>
    /// Gets or sets the old password.
    /// </summary>
    public string OldPassword { get; set; } = null!;


    /// <summary>
    /// Creates new password.
    /// </summary>
    public string NewPassword { get; set; } = null!;
}
