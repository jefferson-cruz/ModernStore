using ModernStore.Domain.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ModernStore.Infra.Common.Email
{
    public class SendGridEmailService : IEmailService
    {
        public void Send(string toName, string toEmail, string subject, string body)
        {
            var apiKey = "YOUR_API_KEY";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("YOUR_EMAIL_FOR_SERVICE_WORK", "Example User");
            var to = new EmailAddress(toEmail, toName);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", body);

            var response = client.SendEmailAsync(msg).Result;
        }
    }
}
