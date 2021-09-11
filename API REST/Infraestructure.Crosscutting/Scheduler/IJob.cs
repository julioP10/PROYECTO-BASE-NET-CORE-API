using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Crosscutting.Scheduler
{
    public interface IJob
    {
        Task Run(JobConfig config);
    }
}
