using GlobalEvents.Application.Interface.Infrastructure;
using GlobalEvents.Application.Model.Mail;
using Microsoft.Extensions.Options;
using PostmarkDotNet;

namespace GlobalEvents.Infrastructure.Mail
{
    public class PostMarkEmailService : IEmailService
    {
        private EmailSettings emailSettings { get; }

        public PostMarkEmailService(IOptions<EmailSettings> mailSettings)
        {
            this.emailSettings = mailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new PostmarkClient(emailSettings.ApiKey);

            var message = new PostmarkMessage
            {
                From = emailSettings.FromAddress,
                TrackOpens = true,
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
