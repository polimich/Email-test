using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Email_test
{
    class MailSender
    {
        private string _fromName = "Mišák";
        private string _from = "black@salami.com";
        private int _port = 2525;
        private string _server = "smtp.mailtrap.io";
        private string _username = "510e1961d39d8d";
        private string _password = "236be4fc26c755";

        public Task SendEmailAsync(string to, string subject, string message)
        {
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress(_fromName, _from));
            msg.To.Add(new MailboxAddress(to));
            msg.Subject = subject;

            var body = new BodyBuilder();
            body.TextBody = message;
            body.HtmlBody = "<p><b>" + message + "</b></p>";
            msg.Body = body.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback =
                    (s, c, h, e) => true;
                client.Connect(_server, _port,
                    MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                client.Authenticate(_username, _password);
                client.Send(msg);
                client.Disconnect(true);
                return Task.FromResult(0);
            }
        }
    }
}
