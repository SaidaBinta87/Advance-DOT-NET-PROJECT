using DLL.EF.Models;
using DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    internal class EmpMgsRepo : Repo, IPRepo<UserQuestions, int, UserQuestions>
    {
        public bool Delete(int id)
        {
            var employee = Get(id);
            if (employee != null)
            {
                db.UserQuestions.Remove(employee);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<UserQuestions> Get()
        {
            var data = db.UserQuestions.ToList();
            return data;
        }

        public UserQuestions Get(int id)
        {
            var emp = db.UserQuestions.FirstOrDefault(sp => sp.Id == id);
            return emp;
        }

        public List<UserQuestions> GetAll(int id)
        {
            var data = db.UserQuestions.Where(em => em.EmpId == id).ToList();
            return data;
        }

        public UserQuestions Update(UserQuestions obj)
        {
            var existing = Get(obj.Id);

            if (existing != null)
            {
                try
                {
                    
                    existing.Answer = obj.Answer;


                    db.SaveChanges();

                    return existing;

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

