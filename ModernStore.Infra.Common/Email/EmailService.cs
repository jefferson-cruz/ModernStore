using ModernStore.Domain.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ModernStore.Infra.Common.Email
{
    public class SendGridEmailService : IEmailService
    {
        public void Send(string toName, string toEmail, string subject, string body)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("jefferson-cruz@hotmail.com.br", "Example User");
            var to = new EmailAddress(toEmail, toName);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", body);

            var response = client.SendEmailAsync(msg).Result;
        }
    }
}
