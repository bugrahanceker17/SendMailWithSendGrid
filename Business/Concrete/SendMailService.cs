using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Business.Concrete
{
    public class SendMailService : ISendMailService
    {
        private readonly IConfiguration _configuration;

        public SendMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Response> SendAsync(string toEmail, string subject, string content)
        {
            string apiKey = _configuration["SendGridApiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@test.com", "Deneme");
            var to = new EmailAddress("test@test.com", "Test");
            const string plainTextContent = "Bu bir deneme mesajıdır.";
            const string htmlContent = "Bu bir deneme mesajıdır.";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            return await client.SendEmailAsync(msg);
        }
    }
}