using DAL.EF.Models;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repos
{
    internal class PersonRepo : Repo, IRepo<Person, int, Person>
    {
        public Person Create(Person obj)
        {
            db.Persons.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> Get()
        {
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person obj)
        {
            throw new NotImplementedException();
        }
    }
}
