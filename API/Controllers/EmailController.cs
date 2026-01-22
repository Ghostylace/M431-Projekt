using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/email")]
public class EmailController : ControllerBase
{

    /// <summary>
    /// Sends an email message using the details provided in the request.
    /// </summary>
    /// <param name="request">An object containing the recipient's email address, subject, and body of the email message. Cannot be null.</param>
    /// <returns>An IActionResult indicating the result of the email send operation. Returns Ok if the email was sent
    /// successfully.</returns>
    [HttpPost]
    public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
    {
        SmtpClient emailClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(
            "gibtnotenanpassung.noreply@gmail.com",
            "txgz hkhl oful ixrf"),
            EnableSsl = true
        };
        // GMail Passwort = GIBZNotenAnpassungPWD67
        MailMessage mail = new MailMessage(
            "gibtnotenanpassung.noreply@gmail.com",
            request.To,
            request.Subject,
            request.Body
        );

        await emailClient.SendMailAsync(mail);
        return Ok();
    }
}