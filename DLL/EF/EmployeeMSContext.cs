using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EF
{
    public class EmployeeMSContext:DbContext
    {
        public DbSet<Employee> Employes{ get; set; }
        public DbSet<UserQuestions> UserQuestions{ get; set; }
    }
}
