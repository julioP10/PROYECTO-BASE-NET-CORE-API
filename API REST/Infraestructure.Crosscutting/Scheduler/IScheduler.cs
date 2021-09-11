using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Crosscutting.Scheduler
{
    public interface IScheduler
    {
        void Register<TJob>(JobConfig config) where TJob : IJob;
        void DeleteJobs(string idMask, string hours);
    }
}
