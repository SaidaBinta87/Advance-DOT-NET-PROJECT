using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITreatmentPlan
    {

        List<TreatmentPlan> GetTreatmentPlansForPsychologist(int psychologistId);

        List<TreatmentPlan> GetActiveTreatmentPlans();

        List<TreatmentPlan> GetTreatmentPlansByDateRange();
        List<TreatmentPlan> GetTreatmentPlansWithSessions(int psychologistId);

        Dictionary<string, int> GetTreatmentPlansStatistics();
    }
}
