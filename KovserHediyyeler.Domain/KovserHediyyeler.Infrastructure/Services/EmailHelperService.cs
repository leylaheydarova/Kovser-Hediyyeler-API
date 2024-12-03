//using KovserHediyyeler.Application.Abstractions;

//namespace KovserHediyyeler.Infrastructure.Services
//{
//    public  class EmailHelperService
//    {
//        private readonly IEmailService _emailService;

//        public EmailHelperService(IEmailService emailService)
//        {
//            _emailService = emailService;
//        }
//        public async Task SendVerificationEmailAsync(string toEmail, string verificationUrl)
//        {
//            var subject = "Hesabınızı Təsdiqləyin";
//            var body = $@"
//            <p>Hörmətli istifadəçi,</p>
//            <p>Sizin hesabınızı təsdiqləmək üçün aşağıdakı keçidə klikləyin:</p>
//            <p><a href='{verificationUrl}'>{verificationUrl}</a></p>
//            <p>Hörmətlə, Kövsər Hədiyyələr Komandası</p>";

//            await _emailService.SendEmailAsync(toEmail, subject, body);
//        }

//        public async Task SendResetPasswordEmailAsync(string toEmail, string resetUrl)
//        {
//            var subject = "Şifrəni Sıfırlamaq üçün İstək";
//            var body = $@"
//            <p>Hörmətli istifadəçi,</p>
//            <p>Sizin üçün şifrəni sıfırlama keçidi yaratdıq. Şifrəni sıfırlamaq üçün aşağıdakı keçidə klikləyin:</p>
//            <p><a href='{resetUrl}'>{resetUrl}</a></p>
//            <p>Hörmətlə, Kövsər Hədiyyələr Komandası</p>";

//            await _emailService.SendEmailAsync(toEmail, subject, body);
//        }
//    }
//}
