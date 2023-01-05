using ConsoleApp1.Models;

namespace ConsoleApp1.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);

       // Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);
    }
}