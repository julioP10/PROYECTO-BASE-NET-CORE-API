using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MainModule.NoSql
{
    public class Sla
    {
        public int? Duration { get; set; }
        public TimeSpan? Time { get; set; }
    }
}
