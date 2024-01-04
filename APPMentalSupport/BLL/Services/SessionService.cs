using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SessionService
    {
        public static List<SessionDTO> GetAllSessions()
        {
            var data = DataAccessFactory.SessionData().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Session, SessionDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<SessionDTO>>(data);
            return ret;
        }

        public static SessionDTO GetSession(int id)
        {
            var data = DataAccessFactory.SessionData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Session, SessionDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<SessionDTO>(data);
            return ret;
        }

        public static void CreateSession(SessionDTO sessionDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SessionDTO, Session>();
            });
            var mapper = new Mapper(config);
            var session = mapper.Map<Session>(sessionDTO);

            DataAccessFactory.SessionData().Create(session);
        }

        public static void UpdateSession(SessionDTO sessionDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SessionDTO, Session>();
            });
            var mapper = new Mapper(config);
            var session = mapper.Map<Session>(sessionDTO);

            DataAccessFactory.SessionData().Update(session);
        }

        public static bool DeleteSession(int id)
        {
            return DataAccessFactory.SessionData().Delete(id);
        }


        public static bool CancelSession(int sessionId)
        {
            return DataAccessFactory.SessionExData().CancelSession(sessionId);
        }

        public static List<SessionDTO> GetCompletedSessions()
        {
            var data = DataAccessFactory.SessionExData().GetCompletedSessions();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Session, SessionDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<SessionDTO>>(data);
            return ret;
        }

        public static List<SessionDTO> GetUpcomingSessions()
        {
            var data = DataAccessFactory.SessionExData().GetUpcomingSessions();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Session, SessionDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<SessionDTO>>(data);
            return ret;
        }

        public static bool MarkAsCompleted(int sessionId)
        {
            return DataAccessFactory.SessionExData().MarkAsCompleted(sessionId);
        }

        public static List<SessionDTO> GetSessionsForPsychologist(int psychologistId)
        {
            var sessions = DataAccessFactory.SessionExData().GetSessionsForPsychologist(psychologistId);

            // Map TreatmentPlan to TreatmentPlanDTO
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Session, SessionDTO>()
                .ForMember(dest => dest.TreatmentPlanId, opt => opt.MapFrom(src => src.TreatmentPlan)));
            var mapper = new Mapper(config);
            var sessionDTO = mapper.Map<List<SessionDTO>>(sessions);

            return sessionDTO;
        }
    }
}
