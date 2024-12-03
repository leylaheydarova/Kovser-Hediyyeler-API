using KovserHediyyeler.Application.Abstractions;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace KovserHediyyeler.Infrastructure.Services
{
    public class GmailEmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public GmailEmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var email = _config["Email:Address"];
            var securityKey = _config["Email:SMTPKey"]; // SMTP Security Key

            // To parametrinin düzgünlüyünü yoxlayaq
            if (string.IsNullOrWhiteSpace(to))
            {
                throw new ArgumentException("To address cannot be null or empty.", nameof(to));
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Kovser Hediyyeler", email));
            message.To.Add(new MailboxAddress("", to)); // To address daxil edilir
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = body // HTML məzmunu
            };
            message.Body = bodyBuilder.ToMessageBody();

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtpClient.Authenticate(email, securityKey);

                await smtpClient.SendAsync(message);
                smtpClient.Disconnect(true);
            }
        }
    }
}
