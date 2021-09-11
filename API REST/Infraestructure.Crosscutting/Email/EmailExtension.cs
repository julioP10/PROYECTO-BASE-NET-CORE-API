using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Crosscutting.Email
{
    public static class EmailExtension
    {
        public static void AddEmailConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailConfig>(configuration.GetSection(nameof(EmailConfig)));
            services.AddTransient<IMailSender, MailSender>();
        }
    }
}
