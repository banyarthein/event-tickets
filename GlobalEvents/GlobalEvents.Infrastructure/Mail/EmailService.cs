using GlobalEvents.Application.Interface.Infrastructure;
using GlobalEvents.Application.Model.Mail;
using Microsoft.Extensions.Options;
using PostmarkDotNet;

namespace GlobalEvents.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        private EmailSettings emailSettings { get; }

        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            this.emailSettings = mailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new PostmarkClient(emailSettings.ApiKey);

            var message = new PostmarkMessage
            {
                From = emailSettings.FromAddress,
                To = email.To,
                Subject = email.Subject,
                HtmlBody = email.Body,
                TextBody = email.Body
            };

            var sendResult = await client.SendMessageAsync(message);

            return (sendResult.Status == PostmarkStatus.Success);
        }
    }
}
