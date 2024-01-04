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
    internal class SessionRepo : Repo, IRepo<Session, int, Session>, ISession
    {


        public Session Create(Session obj)
        {
            db.Sessions.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var session = db.Sessions.Find(id);

            if (session != null)
            {
                // Remove the session from the context and save changes
                db.Sessions.Remove(session);
                db.SaveChanges();
                return db.SaveChanges() > 0;
            }
            return false;
        }
        public List<Session> Get()
        {
            return db.Sessions.ToList();
        }

        public Session Get(int id)
        {
            return db.Sessions.Find(id);
        }
        public bool CancelSession(int sessionId)
        {
            var session = Get(sessionId);

            if (session != null)
            {
                session.IsCancelled = true; //Scheduled,Completed,Cancelled
                session.Status = "Cancelled";
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /* public List<Session> GetCompletedSessions()
         {
             return db.Sessions
                 .Where(s => !s.IsCancelled && s.Status == "Completed")
                 .ToList();
         }*/

        public List<Session> GetCompletedSessions()
        {
            return db.Sessions
                .Where(s => s.EndTime < DateTime.Now || s.IsCancelled || s.Status == "Completed")
                .ToList();
        }

        /* public List<Session> GetUpcomingSessions()
         {
             return db.Sessions
                 .Where(s => !s.IsCancelled && s.Status == "Scheduled")
                 .ToList();
         }*/

        public List<Session> GetUpcomingSessions()
        {
            return db.Sessions
                .Where(s => !s.IsCancelled && (s.Status == "Scheduled" || s.EndTime >= DateTime.Now))
                .ToList();
        }

        public bool MarkAsCompleted(int sessionId)
        {
            var session = Get(sessionId);

            if (session != null)
            {
                session.Status = "Completed";
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public Session Update(Session obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            // Attach the session to the context and mark it as modified
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

            return obj;
        }

        public List<Session> GetSessionsForPsychologist(int psychologistId)
        {
            return db.Sessions.Where(tp => tp.PsychologistId == psychologistId).ToList();
        }

    }
}
