using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/email")]
public class EmailController : ControllerBase
{
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