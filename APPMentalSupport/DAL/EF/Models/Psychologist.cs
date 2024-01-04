using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DAL.EF.Models
{
    public class Psychologist
    {
        [Key]
        public int PsychologistId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Specialization is required")]
        public string Specialization { get; set; }
        // ... other properties

        // Navigation property for one-to-many relationship with Sessions
        public ICollection<Session> Sessions { get; set; }

        // Navigation property for one-to-many relationship with TreatmentPlans
        public ICollection<TreatmentPlan> TreatmentPlans { get; set; }

        // New properties for CV and image
        public string CVPath { get; set; } // Assuming the path to the CV file
        public string ImagePath { get; set; } // Assuming the path to the image file

        public Psychologist()
        {
            Sessions = new List<Session>();
            TreatmentPlans = new List<TreatmentPlan>();
        }
    }
}
