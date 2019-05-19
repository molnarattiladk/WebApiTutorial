using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Tutorial.Models;

namespace WebApi_Tutorial.Data
{
    public interface IPersonRepository
    {
        void Add<T>(T entity) where T : class;
        void Deleted<T>(T entity) where T : class;

        Task<bool> SaveAll();

        Task<IEnumerable<Person>> GetPeople();
        Task<Person> GetPerson(int id);

    }
}
