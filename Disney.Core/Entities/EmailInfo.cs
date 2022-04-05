using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Disney.Core.Entities
{
    public class EmailInfo
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public EmailInfo()
        {
            Sender = "fernandobruzzo7@gmail.com";
            Subject = "Bienvenido";
        }
    }
}