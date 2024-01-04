using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Person, int, Person> PersonData()
        {
            return new PersonRepo();
        }

        public static IRepo<Psychologist, int, Psychologist> PsychologistData()
        {
            return new PsychologistRepo();
        }

        public static IPsychologist PsychologistUpData()
        {
            return new PsychologistRepo();
        }

        public static IRepo<Session, int, Session> SessionData()
        {
            return new SessionRepo();
        }

        public static ISession SessionExData()
        {
            return new SessionRepo();
        }

        public static IRepo<TreatmentPlan, int, TreatmentPlan> TreatmentPlanData()
        {
            return new TreatmentPlanRepo();
        }

        public static ITreatmentPlan TreatmentPlanExData()
        {
            return new TreatmentPlanRepo();
        }

        public static IMessage<Message, int , Message> MessageData()
        {
            return new MessageRepo();
        }
    }
}
