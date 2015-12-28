using Models;

namespace Services.Interfaces
{
    public interface IMailService
    {
        void Send(string recipientEmail, Document[] attachments);
    }
}
