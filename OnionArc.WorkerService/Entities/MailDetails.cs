using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnionArcExample.WorkerService.Entities
{
    public class MailDetails
    {
        [JsonConstructor]
        public MailDetails()
        {

        }
        public string Subject { get; set; }
        #nullable enable
        public string? Sender { get; set; }
        #nullable enable
        public string? From { get; set; }

        #nullable enable
        public Encoding? BodyEncoding { get; set; }

        public string Body { get; set; }

        public string[] To { get; }
    }
}
