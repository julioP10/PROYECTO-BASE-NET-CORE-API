using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MainModule.NoSql
{
    public class Executions
    {
        public Executions()
        {
            Processes = new List<Process>();
            Starters = new List<string>();
        }

        public string ExecutionId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public Audit Audit { get; set; }

        public ICollection<string> Starters { get; set; }
        public ICollection<Process> Processes { get; set; }
    }
}
