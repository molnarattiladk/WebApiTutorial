using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Tutorial.Models;

namespace WebApi_Tutorial.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext _context)
        {
            this._context = _context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Deleted<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            var people = await _context.People.ToListAsync();
            return people;
        }

        public async Task<Person> GetPerson(int id)
        {
            var person = await _context.People.FirstOrDefaultAsync(x => x.Id == id);
            return person;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
