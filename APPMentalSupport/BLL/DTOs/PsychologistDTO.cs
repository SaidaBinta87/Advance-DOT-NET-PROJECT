using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PsychologistDTO
    {

        public int PsychologistId { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Email { get; set; }


        public string PhoneNumber { get; set; }


        public string Specialization { get; set; }

        // ... other properties

        // New properties for CV and image


        public string CVPath { get; set; }


        public string ImagePath { get; set; }

        // Properties for related entities
        public List<SessionDTO> Sessions { get; set; }
        public List<TreatmentPlanDTO> TreatmentPlans { get; set; }

    }
}
