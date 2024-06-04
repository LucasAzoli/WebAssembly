
using JwtLoginOnline.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace projeto.Server.Services
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _context;

        public PersonService(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<List<Person>> AddPerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return await _context.People.ToListAsync();
        }

        public async Task<List<Person>?> DeletePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person is null)
                return null;

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return await _context.People.ToListAsync();
        }

        public async Task<List<Person>> GetAllPersons()
        {
            var persons = await _context.People.ToListAsync();
            return await _context.People.ToListAsync();
        }

        public async Task<Person?> GetPerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person is null)
                return null;
            return person;
        }

        public async Task<List<Person>?> UpdatePerson(int id, Person request)
        {
            var person = await _context.People.FindAsync(id);
            if (person is null)
                return null;

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Age = request.Age;
            person.Number = request.Number;

            await _context.SaveChangesAsync();

            return await _context.People.ToListAsync();
        }
    }
}
