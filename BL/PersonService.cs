using DAL.Data;
using DAL.Entities;
using System.Reflection.Metadata.Ecma335;

namespace BL
{
    public class PersonService
    {
        private readonly PersonData _personData;

        public PersonService(PersonData personData)
        {
            _personData = personData;
        }

        public async Task<Person?> GetByIdAsync(int personId)
        {
            if (personId <= 0)
                return null;
            return await _personData.GetByIdAsync(personId);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _personData.GetAllAsync();
        }

        public async Task<List<Person>> GetAllTrackedAsync()
        {
            return await _personData.GetAllTrackedAsync();
        }

        public async Task AddAsync(Person person)
        {
            await _personData.AddAsync(person);
        }

        public async Task UpdateAsync(Person person)
        {
            await _personData.UpdateAsync(person);
        }

        public async Task<bool> DeleteAsync(int personId)
        {
            return await _personData.DeleteAsync(personId);
        }
    }
}
