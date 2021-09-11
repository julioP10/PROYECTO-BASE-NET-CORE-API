using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MainModule.NoSql
{
    public class Process
    {
        public Process(string id, string name)
        {
            Id = id;
            Name = name;
            States = new List<State>();
            Logs = new List<Log>();
        }

        public Process()
        {
            States = new List<State>();
            Logs = new List<Log>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<State> States { get; set; }
        public ICollection<Log> Logs { get; set; }
    }
}
