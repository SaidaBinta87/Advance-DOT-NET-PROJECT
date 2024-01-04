using DLL.EF;
using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DLL.Repository
{
    internal class EmployeeRepo : Repo, IRepo<Employee, string, Employee,int>
    {
        public Employee Authenticate(string email, string password)
        {
            
            var employee = db.Employes.FirstOrDefault(em => em.Email == email && em.Password == password);
            return employee;
        }

        public Employee Create(Employee obj)
        {
            db.Employes.Add(obj);
            db.SaveChanges();
            return obj;
        }


        public bool Delete(int id)
        {
            var employee = Read(id);
            if (employee != null)
            {
                db.Employes.Remove(employee);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Employee> Get()
        {
            var data = db.Employes.ToList();
            return data;
        }

        public List<Employee> Get(string id)
        {
            var data = db.Employes.Where(em => em.Email == id).ToList();
            return data;
        }

        public Employee Read(int id)
        {
            var emp = db.Employes.FirstOrDefault(sp => sp.Id == id);
            return emp;
        }

        public Employee Update(Employee obj)
        {
            var existingEmployee = Read(obj.Id);

            if (existingEmployee != null)
            {
                try
                {
                   
                    db.Entry(existingEmployee).CurrentValues.SetValues(obj);
                    if (db.SaveChanges() > 0)
                        return obj;
                }
                catch 
                {
                    return null;
                }
            }
            return null; 
        }



    }
}
