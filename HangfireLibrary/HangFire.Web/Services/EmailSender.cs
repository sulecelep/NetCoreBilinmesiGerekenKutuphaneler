using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace HangFire.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Sender(string userId, string message)
        {
            //bu userId'ye sahip kullanıcıyı bul ve email adresini al
            var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
                //Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("ssulecelepp@gmail.com", "Example User");
            var subject = "www.mysite.com bilgilendirme";
            var to = new EmailAddress("sulecelep94@gmail.com", "Example User");
            //var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
