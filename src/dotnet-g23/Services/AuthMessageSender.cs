using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace dotnet_g23.Services {
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender
    {
        public void SendEmailAsync(string receiver, string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Goed Bezig!", "goedbezig@dejonckhee.re"));
            emailMessage.To.Add(new MailboxAddress(receiver, email));
            emailMessage.Subject = subject;

            emailMessage.Body = new TextPart(TextFormat.Text) {
                Text = message
            };

            using (var client = new SmtpClient()) {
                client.Connect("thalarion.be", 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("goedbezig@dejonckhee.re", "z5sG3kEVioUhhqhosXgT4xWSsGzG8biMKYz1BmQPmYRUFzAD1G8nBozfdcvUnuU9UbojEUsvStA");

                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}