using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISession
    {
        bool CancelSession(int sessionId);
        bool MarkAsCompleted(int sessionId);
        List<Session> GetCompletedSessions();
        List<Session> GetUpcomingSessions();
        List<Session> GetSessionsForPsychologist(int psychologistId);
    }
}
