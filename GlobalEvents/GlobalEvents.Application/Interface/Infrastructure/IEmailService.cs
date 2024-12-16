using GlobalEvents.Application.Model.Mail;

namespace GlobalEvents.Application.Interface.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
