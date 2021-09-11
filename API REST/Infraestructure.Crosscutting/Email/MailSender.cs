using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace Infraestructure.Crosscutting.Email
{
    public class MailSender : IMailSender
    {
        private readonly EmailConfig _emailConfig;

        public MailSender(IOptions<EmailConfig> emailOptions)
        {
            _emailConfig = emailOptions.Value;
        }

        public async Task SendAsync(EmailMessage emailMessage)
        {
            var receivers = emailMessage.To.Split(",");
            var copyReceivers = string.IsNullOrEmpty(emailMessage.Cc) ? new string[0] : emailMessage.Cc.Split(",");
            var hiddenCopyReceivers = string.IsNullOrEmpty(emailMessage.Bcc) ? new string[0] : emailMessage.Bcc.Split(",");

            var bodyBuilder = new BodyBuilder();
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailMessage.From ?? _emailConfig.Sender));

            foreach (var receiver in receivers)
            {
                message.To.Add(new MailboxAddress(receiver));
            }

            foreach (var copyReceiver in copyReceivers)
            {
                message.Cc.Add(new MailboxAddress(copyReceiver));
            }

            foreach (var hiddenCopyReceiver in hiddenCopyReceivers)
            {
                message.Bcc.Add(new MailboxAddress(hiddenCopyReceiver));
            }

            message.Subject = emailMessage.Subject;

            bodyBuilder.HtmlBody = emailMessage.Body;
            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                ServerCertificateValidationCallback = (s, c, h, e) => true
            };

            await client.ConnectAsync(_emailConfig.Server, _emailConfig.Port, _emailConfig.UseSsl);

            await client.AuthenticateAsync(_emailConfig.User, _emailConfig.Password);

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
