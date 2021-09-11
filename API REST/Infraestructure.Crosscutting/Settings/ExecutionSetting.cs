using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Crosscutting.Settings
{
    public class ExecutionSetting
    {
        public string Url { get; set; }
        public int TimeOut { get; set; }
        public string NotificationQueue { get; set; }
        public string OrchestrationQueue { get; set; }
    }
}
