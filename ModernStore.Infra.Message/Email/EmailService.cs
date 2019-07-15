using ModernStore.Domain.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Message.Email
{
    public class EmailService : IEmailService
    {
        public void Send(string toName, string toEmail, string subject, string body)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var to = new EmailAddress(toEmail, toName);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", body);

            var response = client.SendEmailAsync(msg).Result;
        }
    }
}
