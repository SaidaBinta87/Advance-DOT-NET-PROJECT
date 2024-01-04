using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SessionDTO
    {
        public int SessionId { get; set; }
    
        public int? PsychologistId { get; set; }

     
        public int? TreatmentPlanId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string SessionNotes { get; set; }
        public bool IsCancelled { get; set; }
        public string Status { get; set; }

    }
}
