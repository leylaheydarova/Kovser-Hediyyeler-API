//using KovserHedieyyeler.Application.Abstractions.Services;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Mail;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace KovserHediyyeler.Infrastructure.Services
//{
//    public class MailService:IMailService
//    {
//        readonly IConfiguration _configuration;

//        public MailService(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public async Task SendCompletedOrderMailAsync(string to, string orderCode, DateTime orderDate, string userName)
//        {
//            string mail = $"Hörmətli {userName}, Salam<br>" +
//                $"{orderDate} tarixində verdiyiniz {orderCode} kodlu sifarişiniz tamamlanmış ve kargo firmasına verilmişdir.<br>Bizi seçdiyiniz üçün təşəkkür edirik!";

//            await SendMailAsync(to, $"{orderCode} Sifariş Nömrəli Sifarişiniz Tamamlandı", mail);
//        }

//        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
//        {
//            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
//        }

//        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
//        {
//            MailMessage mail = new();
//            mail.IsBodyHtml = isBodyHtml;
//            foreach (var to in tos)
//                mail.To.Add(to);
//            mail.Subject = subject;
//            mail.Body = body;
//            mail.From = new(_configuration["Mail:Username"], "Kövsər Hədiyyələr", System.Text.Encoding.UTF8);

//            SmtpClient smtp = new();
//            smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
//            smtp.Port = 587;
//            smtp.EnableSsl = true;
//            smtp.Host = _configuration["Mail:Host"];
//            await smtp.SendMailAsync(mail);
//        }

//        public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
//        {
//            StringBuilder mail = new();
//            mail.AppendLine("Salam!<br>Yeni şifrə üçün aşağıdakı link-ə keçid edə bilərsiniz..<br><strong><a target=\"_blank\" href=\"");
//            mail.AppendLine(_configuration["Next.jsClientURL"]);
//            mail.AppendLine("/update-password/");
//            mail.AppendLine(userId);
//            mail.AppendLine("/");
//            mail.AppendLine(resetToken);
//            mail.AppendLine("\">Yeni şifrə üçün klikləyin...</a></strong><br><br><span style=\"font-size:12px;\">NOT : Əgər belə bir tələbə baş vurmamısınızsa, zəhmət olmasa bu email-i ciddiyə almayın.</span><br>Hörmətlə...<br><br><br>Kövsər Hədiyyələr");

//            await SendMailAsync(to, "Şifrə yeniləmə tələbi", mail.ToString());
//        }
//    }
//}
