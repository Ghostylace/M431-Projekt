namespace Shared.DTOs.Prorektor;

public class ProrektorDTO
{

    /// <summary>Gets or sets the identifier.</summary>
    public int Id { get; set; }

    /// <summary>Gets or sets the vorname.</summary>
    public string Vorname { get; set; } = string.Empty;

    /// <summary>Gets or sets the nachname.</summary>
    public string Nachname { get; set; } = string.Empty;

    /// <summary>Gets or sets the email.</summary>
    public string Email { get; set; } = string.Empty;
}
