using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCVCore.EntityLayer.Concrete
{
    public class WriterMessage
    {
        public int WriterMessageId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string? Subject { get; set; }
        //public string? Content { get; set; }
        public string? MessageContent { get; set; }
        public DateTime? Date { get; set; }
    }
}
