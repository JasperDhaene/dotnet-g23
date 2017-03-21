using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace dotnet_g23.Services {
    public class MailHelper {
        private const int Timeout = 180000;
        private readonly string _host;
        private readonly int _port;
        private readonly string _user;
        private readonly string _pass;
        private readonly bool _ssl;

        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string AttachmentFile { get; set; }

        public MailHelper() {
            //MailServer - Represents the SMTP Server
            _host = "thalarion.be";
            //Port- Represents the port number
            _port = 587;
            //MailAuthUser and MailAuthPass - Used for Authentication for sending email
            _user = "goedbezig@dejonckhee.re";
            _pass = "z5sG3kEVioUhhqhosXgT4xWSsGzG8biMKYz1BmQPmYRUFzAD1G8nBozfdcvUnuU9UbojEU";
            _ssl = false;
        }

        public void Send() {
            try {

                // We do not catch the error here... let it pass direct to the caller
                var message = new MailMessage(Sender, Recipient, Subject, Body) { IsBodyHtml = true };

                var smtp = new SmtpClient(_host, _port);

                if (_user.Length > 0 && _pass.Length > 0) {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_user, _pass);
                    smtp.EnableSsl = _ssl;
                }

                smtp.Send(message);

                if (att != null)
                    att.Dispose();
                message.Dispose();
                smtp.Dispose();
            }

            catch (Exception ex) {

            }
        }
    }
}
