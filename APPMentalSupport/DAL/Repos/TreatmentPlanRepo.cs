using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TreatmentPlanRepo : Repo, IRepo<TreatmentPlan, int, TreatmentPlan>, ITreatmentPlan
    {
        public TreatmentPlan Create(TreatmentPlan obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            // Add the treatment plan to the context and save changes
            db.TreatmentPlans.Add(obj);
            db.SaveChanges();

            return obj;
        }

        public bool Delete(int id)
        {
            // Find the treatment plan with the given id
            var treatmentPlan = db.TreatmentPlans.Find(id);

            if (treatmentPlan != null)
            {
                // Remove the treatment plan from the context and save changes
                db.TreatmentPlans.Remove(treatmentPlan);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public List<TreatmentPlan> Get()
        {
            // Retrieve all treatment plans from the context
            return db.TreatmentPlans.ToList();
        }

        public TreatmentPlan Get(int id)
        {
            // Find and return the treatment plan with the given id
            return db.TreatmentPlans.Find(id);
        }

        public TreatmentPlan Update(TreatmentPlan obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            // Attach the treatment plan to the context and mark it as modified
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

            return obj;
        }

        public List<TreatmentPlan> GetTreatmentPlansForPsychologist(int psychologistId)
        {
            return db.TreatmentPlans
      
        .Where(tp => tp.PsychologistId == psychologistId)
        .ToList();
        }

        public List<TreatmentPlan> GetActiveTreatmentPlans()
        {
            return db.TreatmentPlans
                .Where(tp => tp.PlanEndDate >= DateTime.Now)
                .ToList();
        }

        public List<TreatmentPlan> GetTreatmentPlansByDateRange()
        {
            var startDate = new DateTime(2023, 1, 1);
            var endDate = new DateTime(2024, 12, 31);
            return db.TreatmentPlans
                .Where(tp => tp.PlanStartDate >= startDate && tp.PlanEndDate <= endDate)
                .ToList();
        }

        public List<TreatmentPlan> GetTreatmentPlansWithSessions(int psychologistId)
        {
            // Include sessions related to each treatment plan
            return db.TreatmentPlans
                .Include(tp => tp.Sessions)
                .Where(tp => tp.PsychologistId == psychologistId)
                .ToList();
        }

        public Dictionary<string, int> GetTreatmentPlansStatistics()
        {
           
            var activeCount = db.TreatmentPlans.Count(tp => tp.PlanEndDate >= DateTime.Now);
            var completedCount = db.TreatmentPlans.Count(tp => tp.PlanEndDate < DateTime.Now);

            var statistics = new Dictionary<string, int>
            {
                { "ActiveTreatmentPlans", activeCount },
                { "CompletedTreatmentPlans", completedCount }
            };

            return statistics;
        }
    }
}
