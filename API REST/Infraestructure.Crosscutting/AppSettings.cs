using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Crosscutting
{
    public class AppSettings
    {
        public IEnumerable<string> ConnectionString { get; set; }
        public string Token { get; set; }
        public Polly Polly { get; set; }
        public IEnumerable<string> PathIgnore { get; set; }
        public SettingEndPoint SettingEndPoint { get; set; }
    }
    public class Polly
    {
        public int Intent { get; set; }
        public int Delay { get; set; }
    }
    public class SettingEndPoint
    {
        public string ClientMicroservice { get; set; }
        public string ProductMicroservice { get; set; }
        public string OrderMicroservice { get; set; }
    }
}
