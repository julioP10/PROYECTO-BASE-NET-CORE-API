using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Crosscutting.Email
{
    public class EmailConfig
    {
        public string Sender { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
