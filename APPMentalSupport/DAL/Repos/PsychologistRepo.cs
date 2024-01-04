using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PsychologistRepo : Repo, IRepo<Psychologist, int, Psychologist>, IPsychologist
    {
        public Psychologist Create(Psychologist obj)
        {
            db.Psychologists.Add(obj);
            db.SaveChanges();
            return obj;


        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Psychologists.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Psychologist> Get()
        {
            return db.Psychologists.ToList();
        }

        public Psychologist Get(int id)
        {
            return db.Psychologists.Find(id);
        }

        /*public Psychologist GetPsychologistWithDetails(int psychologistId)
        {
            return db.Psychologists.Include("Sessions").Include("TreatmentPlans").FirstOrDefault(p => p.PsychologistId == psychologistId);
        }*/

        public Psychologist GetPsychologistWithDetails(int psychologistId)
        {
            return db.Psychologists
                
                .FirstOrDefault(p => p.PsychologistId == psychologistId);
        }

        /*  public Psychologist Update(Psychologist obj)
          {//
              var ex = Get(obj.PsychologistId);
              db.Entry(ex).CurrentValues.SetValues(obj);
              return ex;
          }*/

        public Psychologist Update(Psychologist obj)
        {
            var existingPsychologist = Get(obj.PsychologistId);

            if (existingPsychologist != null)
            {
                db.Entry(existingPsychologist).CurrentValues.SetValues(obj);
                return existingPsychologist;
            }
            else
            {
                // Handle the case where the psychologist is not found
                throw new Exception("Psychologist not found");
            }
        }

        public void UploadCV(int psychologistId, string cvFilePath)
        {
            var psychologist = Get(psychologistId);
            psychologist.CVPath = cvFilePath;
            db.SaveChanges();
        }

        public void UploadImage(int psychologistId, string imagePath)
        {
            var psychologist = Get(psychologistId);
            psychologist.ImagePath = imagePath;
            db.SaveChanges();
        }

        public string GetCVPath(int psychologistId)
        {
            var psychologist = Get(psychologistId);
            return psychologist?.CVPath;
        }

        public string GetImagePath(int psychologistId)
        {
            var psychologist = Get(psychologistId);
            return psychologist?.ImagePath;
        }

        // Helper method to read file content
        private string ReadFileContent(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., file not found)
                return $"Error reading file: {ex.Message}";
            }
        }

        // New methods to get actual CV and image content
        public string GetCVContent(int psychologistId)
        {
            var cvPath = GetCVPath(psychologistId);
            return ReadFileContent(cvPath);
        }

        public string GetImageContent(int psychologistId)
        {
            var imagePath = GetImagePath(psychologistId);
            return ReadFileContent(imagePath);
        }
    }
}
