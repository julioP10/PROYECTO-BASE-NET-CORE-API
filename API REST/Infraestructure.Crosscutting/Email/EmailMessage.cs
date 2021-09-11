namespace Infraestructure.Crosscutting.Email
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string From { get; set; }
    }
}
