
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TreatmentPlanDTO
    {
        public int TreatmentPlanId { get; set; }
        public int PsychologistId { get; set; }
        public DateTime PlanStartDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public string PlanDetails { get; set; }

        public List<SessionDTO> Sessions { get; set; }
    }
}
