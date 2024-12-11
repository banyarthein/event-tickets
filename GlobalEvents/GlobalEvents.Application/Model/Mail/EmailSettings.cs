using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Model.Mail
{
    public class EmailSettings
    {
        public string ApiURL { get; set; }
        public string ApiKey { get; set; }
        public string SMTPAddress { get; set; }
        public string SMTPPort { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
    }
}
