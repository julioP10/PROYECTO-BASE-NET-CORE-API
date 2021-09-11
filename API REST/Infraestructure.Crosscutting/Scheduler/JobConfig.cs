using System;

namespace Infraestructure.Crosscutting.Scheduler
{
    [Serializable]
    public class JobConfig
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public object Parameter { get; set; }
        public DateTime StartDate { get; set; }
        public string Hours { get; set; }
        public int Frequency { get; set; }
        public int? FrequencyInterval { get; set; }
        public string DaysRepeat { get; set; }
        public DateTime? EndDate { get; set; }
        public int? RepetitionNumber { get; set; }
    }
}
