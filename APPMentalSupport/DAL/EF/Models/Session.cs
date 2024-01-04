using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }

        [ForeignKey("Psychologist")]
        public int? PsychologistId { get; set; }
        public virtual Psychologist Psychologist { get; set; }
        [ForeignKey("TreatmentPlan")]
        public int? TreatmentPlanId { get; set; }
        public virtual TreatmentPlan TreatmentPlan { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Location { get; set; }
        public string SessionNotes { get; set; }
        public bool IsCancelled { get; set; }
        public string Status { get; set; }//Scheduled,Completed,Cancelled
    }
}
