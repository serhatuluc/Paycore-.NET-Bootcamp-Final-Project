using OnionArcExample.Application.Common.Interfaces.Services.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.Common.Interfaces.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
