using DLL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    internal class Repo
    {
        protected EmployeeMSContext db;

        protected Repo()
        {
            db = new EmployeeMSContext();
        }
    }
}
