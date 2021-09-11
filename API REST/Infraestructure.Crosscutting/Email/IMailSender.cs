using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Crosscutting.Email
{
    public interface IMailSender
    {
        Task SendAsync(EmailMessage emailMessage);
    }
}
