using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class TreatmentPlan
    {
        [Key]
        public int TreatmentPlanId { get; set; }

        [ForeignKey("Psychologist")]
        public int PsychologistId { get; set; }
        public virtual Psychologist Psychologist { get; set; }


        public DateTime PlanStartDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public string PlanDetails { get; set; }

        public ICollection<Session> Sessions { get; set; }

        public TreatmentPlan()
        {
            Sessions = new List<Session>();

        }
    }
}
