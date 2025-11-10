using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace JamesThew.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var senderEmail = _config["EmailSettings:SenderEmail"];
            var senderPassword = _config["EmailSettings:SenderPassword"];
            var host = _config["EmailSettings:Host"];
            var portValue = _config["EmailSettings:Port"];

            int port = int.TryParse(portValue, out int parsedPort) ? parsedPort : 587;

            var client = new SmtpClient(host)
            {
                Port = port,
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true,
                // 🛑 YEH LINE ZAROORI HAI:
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            var mail = new MailMessage
            {
                From = new MailAddress(senderEmail),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            mail.To.Add(email);

            return client.SendMailAsync(mail);
        }
    }
}
