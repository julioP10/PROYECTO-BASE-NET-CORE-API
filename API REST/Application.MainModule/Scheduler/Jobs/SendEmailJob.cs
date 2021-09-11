using AutoMapper;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Domain.MainModule.NoSql;
using Infraestructure.Crosscutting.Email;
using Infraestructure.Crosscutting.Enums;
using Infraestructure.Crosscutting.Scheduler;
using System.Threading.Tasks;

namespace Application.MainModule.Scheduler.Jobs
{
    public class SendEmailJob : IJob
    {
        protected readonly IMapper _mapper;
        private readonly IMailSender _mailSender; 

        public SendEmailJob(
            IMailSender mailSender,
            IMapper mapper  )
        {
            _mailSender = mailSender; 
            _mapper = mapper; 
        }

        public async Task Run(JobConfig config)
        {
            var automaticMailId = config.Id;
            //var automaticMailConfig = await _mailRepository.GetAsync(automaticMailId);

            //var message = _mapper.Map<EmailMessage>(automaticMailConfig);

            await _mailSender.SendAsync(null); 
        }
    }
}
