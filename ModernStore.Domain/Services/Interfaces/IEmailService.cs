namespace ModernStore.Domain.Services.Interfaces
{
    public interface IEmailService
    {
        void Send(string toName, string toEmail, string subject, string body);
    }
}
