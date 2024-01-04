using AutoMapper;
using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PsychologistService
    {
        public static List<PsychologistDTO> GetAllPsychologists()
        {
            var data = DataAccessFactory.PsychologistData().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DAL.EF.Models.Psychologist, PsychologistDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<PsychologistDTO>>(data);
            return ret;
        }

        public static PsychologistDTO GetPsychologist(int id)
        {
            var data = DataAccessFactory.PsychologistData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DAL.EF.Models.Psychologist, PsychologistDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<PsychologistDTO>(data);
            return ret;
        }

        public static void CreatePsychologist(PsychologistDTO psychologistDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PsychologistDTO, DAL.EF.Models.Psychologist>();
            });
            var mapper = new Mapper(config);
            var psychologist = mapper.Map<DAL.EF.Models.Psychologist>(psychologistDTO);

            DataAccessFactory.PsychologistData().Create(psychologist);
        }

        /*  public static void UpdatePsychologist(PsychologistDTO psychologistDTO)
          {
             // var config = new MapperConfiguration(cfg => {
                  cfg.CreateMap<PsychologistDTO, DAL.EF.Models.Psychologist>();
              });
              var mapper = new Mapper(config);
              var psychologist = mapper.Map<DAL.EF.Models.Psychologist>(psychologistDTO);

              DataAccessFactory.PsychologistData().Update(psychologist);
          }*/
        public static void UpdatePsychologist(int psychologistId, PsychologistDTO psychologistDTO)
        {
            var existingPsychologist = DataAccessFactory.PsychologistData().Get(psychologistId);

            if (existingPsychologist != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PsychologistDTO, DAL.EF.Models.Psychologist>();
                });
                var mapper = new Mapper(config);

                // Apply changes to the existing psychologist
                var updatedPsychologist = mapper.Map(psychologistDTO, existingPsychologist);

                DataAccessFactory.PsychologistData().Update(updatedPsychologist);
            }
            else
            {
                // Handle the case where the psychologist with the given ID is not found
                throw new Exception("Psychologist not found");
            }
        }


        public static void UploadCV(int psychologistId, string cvFilePath)
        {
            DataAccessFactory.PsychologistUpData().UploadCV(psychologistId, cvFilePath);
        }

        public static void UploadImage(int psychologistId, string imagePath)
        {
            DataAccessFactory.PsychologistUpData().UploadImage(psychologistId, imagePath);
        }

         public static PsychologistDTO GetPsychologistWithDetails(int psychologistId)
         {
             var data = DataAccessFactory.PsychologistUpData().GetPsychologistWithDetails(psychologistId);
             var config = new MapperConfiguration(cfg => {
                 cfg.CreateMap<DAL.EF.Models.Psychologist, PsychologistDTO>();
                     // Add this line
             });
             var mapper = new Mapper(config);
             var ret = mapper.Map<PsychologistDTO>(data);
             return ret;
         }


       /* public static PsychologistDTO GetPsychologistWithDetails(int psychologistId)
        {
            var data = DataAccessFactory.PsychologistUpData().GetPsychologistWithDetails(psychologistId);

            // Ensure related entities are loaded
            if (data != null)
            {
                // Assuming Sessions and TreatmentPlans are navigation properties in Psychologist model
                // You might need to adjust this based on your actual model
                var sessions = DataAccessFactory.SessionExData().GetSessionsForPsychologist(psychologistId);
                var treatmentPlans = DataAccessFactory.TreatmentPlanExData().GetTreatmentPlansForPsychologist(psychologistId);

                data.Sessions = sessions;
                data.TreatmentPlans = treatmentPlans;
            }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DAL.EF.Models.Psychologist, PsychologistDTO>();
            });

            var mapper = new Mapper(config);
            var ret = mapper.Map<PsychologistDTO>(data);
            return ret;
        }*/

        public static string GetCVContent(int psychologistId)
        {
            return DataAccessFactory.PsychologistUpData().GetCVContent(psychologistId);
        }

        public static string GetImageContent(int psychologistId)
        {
            return DataAccessFactory.PsychologistUpData().GetImageContent(psychologistId);
        }




    }
}
