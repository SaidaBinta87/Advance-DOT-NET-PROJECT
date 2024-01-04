using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPsychologist
    {


        // Other methods common to all users (if any)

        // Methods specific to Psychologist
        void UploadCV(int psychologistId, string cvFilePath);
        void UploadImage(int psychologistId, string imagePath);
        Psychologist GetPsychologistWithDetails(int psychologistId);
        string GetCVPath(int psychologistId);
        string GetImagePath(int psychologistId);
        string GetCVContent(int psychologistId);
        string GetImageContent(int psychologistId);

    }
}
