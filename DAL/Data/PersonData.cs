using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class PersonData
    {
        /*
        Because database operations are mostly I/O-bound: your program sends a query to SQL Server, 
        then waits for SQL Server to respond.
        Using async/await lets your thread do other work instead of sitting blocked during that wait.
        */

        private readonly AppDbContext _context;

        public PersonData(AppDbContext context)
        {
            _context = context;
        }

        //Read (get by id, get all)
        public async Task<Person?> GetByIdAsync(int personId)
        {
            return
                await _context.People.FindAsync(personId);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await
                _context.People
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Person>> GetAllTrackedAsync()
        {
            return await
                _context.People.ToListAsync();
        }

        public async Task AddAsync(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            _context.People.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Person person)
        {
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// This is better than passing the person as argument, because the caller does not need to 
        /// retrieve the entity to delete it
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int personId)
        {
            var person = _context.People.Find(personId);
            if (person is null)
                return false;
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
