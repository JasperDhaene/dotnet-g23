using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace dotnet_g23.Services {
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender {
        public void SendEmailAsync(string organizationName, string receiver, string beschrijving, string email, string subject, string message) {
            // Plug in your email service here to send an email.
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Goed Bezig!", "goedbezig@dejonckhee.re"));
            emailMessage.To.Add(new MailboxAddress(receiver, email));
            emailMessage.Subject = subject;

            emailMessage.Body = new TextPart(TextFormat.Text) {
                Text = "Geachte \n" +
                "Omdat het deugd doet om een compliment te krijgen en omdat iedereen een extra hart onder de riem best kan gebruiken, " +
                "nemen wij, cursisten van "+ organizationName +", deel aan het initiatief ‘Goed bezig!’.\n\n" +
                "Via het initiatief ‘Goed bezig!’ geven we een label als erkenning aan een organisatie waarvan wij vinden dat deze goed bezig is.\n\n" +
                "Wij hebben jullie, " + receiver + " , gekozen omdat we het enorm waarderen dat jullie " + beschrijving + ". "+
                "Jullie doen dit vrijwillig en zetten jullie elke dag belangeloos in!Jullie zijn ‘Goed bezig!’\n\n"+
                "Jullie krijgen niet alleen het label, we steken ook graag de handen uit de mouwen om jullie te ondersteunen.We hebben reeds enkele ideeën rond mogelijke acties, "+
                "en hadden deze graag aan jullie voorgesteld.\n\n"+
                "Het digitale label kunnen jullie hier alvast bekijken en delen via onze facebookpagina: www.facebook.com/jebentgoedbezig \n\n"+
                "Met vriendelijke groet"
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