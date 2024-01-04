using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TreatmentPlanService
    {
        public static List<TreatmentPlanDTO> GetAllTreatmentPlans()
        {
            var data = DataAccessFactory.TreatmentPlanData().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DAL.EF.Models.TreatmentPlan, TreatmentPlanDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<TreatmentPlanDTO>>(data);
            return ret;
        }

        public static TreatmentPlanDTO GetTreatmentPlan(int id)
        {
            var data = DataAccessFactory.TreatmentPlanData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DAL.EF.Models.TreatmentPlan, TreatmentPlanDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<TreatmentPlanDTO>(data);
            return ret;
        }

        public static void CreateTreatmentPlan(TreatmentPlanDTO treatmentPlanDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TreatmentPlanDTO, DAL.EF.Models.TreatmentPlan>();
            });
            var mapper = new Mapper(config);
            var treatmentPlan = mapper.Map<DAL.EF.Models.TreatmentPlan>(treatmentPlanDTO);

            DataAccessFactory.TreatmentPlanData().Create(treatmentPlan);
        }

        public static void UpdateTreatmentPlan(TreatmentPlanDTO treatmentPlanDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TreatmentPlanDTO, DAL.EF.Models.TreatmentPlan>();
            });
            var mapper = new Mapper(config);
            var treatmentPlan = mapper.Map<DAL.EF.Models.TreatmentPlan>(treatmentPlanDTO);

            DataAccessFactory.TreatmentPlanData().Update(treatmentPlan);
        }

        public static void DeleteTreatmentPlan(int id)
        {
            DataAccessFactory.TreatmentPlanData().Delete(id);
        }
        public TreatmentPlanDTO GetTreatmentPlanDetails(int treatmentPlanId)
        {
            var treatmentPlan = DataAccessFactory.TreatmentPlanData().Get(treatmentPlanId);

            // Map TreatmentPlan to TreatmentPlanDTO
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TreatmentPlan, TreatmentPlanDTO>()
                    .ForMember(dest => dest.Sessions, opt => opt.MapFrom(src => src.Sessions));

                cfg.CreateMap<Session, SessionDTO>();  // Add this mapping configuration
            });
            var mapper = new Mapper(config);
            var treatmentPlanDTO = mapper.Map<TreatmentPlanDTO>(treatmentPlan);

            return treatmentPlanDTO;
        }

        public static List<TreatmentPlanDTO> GetTreatmentPlansForPsychologist(int psychologistId)
        {
            var treatmentPlans = DataAccessFactory.TreatmentPlanExData().GetTreatmentPlansForPsychologist(psychologistId);

            // Map TreatmentPlan to TreatmentPlanDTO
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TreatmentPlan, TreatmentPlanDTO>()
                .ForMember(dest => dest.Sessions, opt => opt.MapFrom(src => src.Sessions)));
            var mapper = new Mapper(config);
            var treatmentPlansDTO = mapper.Map<List<TreatmentPlanDTO>>(treatmentPlans);

            return treatmentPlansDTO;
        }

        // Other methods for different TreatmentPlan features

        // Example: Get active treatment plans
        public static List<TreatmentPlanDTO> GetActiveTreatmentPlans()
        {
            var activeTreatmentPlans = DataAccessFactory.TreatmentPlanExData().GetActiveTreatmentPlans();

            // Map TreatmentPlan to TreatmentPlanDTO
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TreatmentPlan, TreatmentPlanDTO>()
                .ForMember(dest => dest.Sessions, opt => opt.MapFrom(src => src.Sessions)));
            var mapper = new Mapper(config);
            var activeTreatmentPlansDTO = mapper.Map<List<TreatmentPlanDTO>>(activeTreatmentPlans);

            return activeTreatmentPlansDTO;
        }
        public static List<TreatmentPlanDTO> GetTreatmentPlansByDateRange()
        {
            var treatmentPlans = DataAccessFactory.TreatmentPlanExData().GetTreatmentPlansByDateRange();

            // Map TreatmentPlan to TreatmentPlanDTO
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TreatmentPlan, TreatmentPlanDTO>()
                .ForMember(dest => dest.Sessions, opt => opt.MapFrom(src => src.Sessions)));
            var mapper = new Mapper(config);
            var treatmentPlansDTO = mapper.Map<List<TreatmentPlanDTO>>(treatmentPlans);

            return treatmentPlansDTO;
        }

        public static List<TreatmentPlanDTO> GetTreatmentPlansWithSessions(int psychologistId)
        {
            var treatmentPlans = DataAccessFactory.TreatmentPlanExData().GetTreatmentPlansWithSessions(psychologistId);

            // Map TreatmentPlan to TreatmentPlanDTO
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TreatmentPlan, TreatmentPlanDTO>();
            });
            var mapper = new Mapper(config);
         var treatmentPlansDTO = mapper.Map<List<TreatmentPlanDTO>>(treatmentPlans);
            return treatmentPlansDTO;
        }

        public static Dictionary<string, int> GetTreatmentPlansStatistics()
        {
            var statistics = DataAccessFactory.TreatmentPlanExData().GetTreatmentPlansStatistics();

            // You may want to map this to a DTO if needed

            return statistics;
        }

    }
}
