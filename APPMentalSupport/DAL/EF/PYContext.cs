using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class PYContext : DbContext
    {
        public PYContext()
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Psychologist> Psychologists { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<TreatmentPlan> TreatmentPlans { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Employee> Employes { get; set; }
        public DbSet<UserQuestions> UserQuestions { get; set; }
    }
}
