using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation properties
        public int SenderId { get; set; }
        public Psychologist SenderPsychologist { get; set; }
        public int ReceiverId { get; set; }
        public Person ReceiverPerson { get; set; }
    }
}
