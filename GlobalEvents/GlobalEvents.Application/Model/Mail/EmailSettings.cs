namespace GlobalEvents.Application.Model.Mail
{
    public class EmailSettings
    {
        public bool isAPIEmail { get; set; } = false;
        public string ApiURL { get; set; }
        public string ApiKey { get; set; }

        public string SMTPAddress { get; set; }
        public string SMTPPort { get; set; }

        public string FromName { get; set; }
        public string FromAddress { get; set; }
    }
}
