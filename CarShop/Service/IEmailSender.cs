using Entity;

namespace CarShop.Service
{
    public interface IEmailSender
    {
        Task SendEmail(byte[] attachmentData, string attachmentName, Person person, string clientEmail, string plate);
    }
}
