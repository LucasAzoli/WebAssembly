using projeto.Shared.Models;

namespace projeto.Client.Service
{
    public interface IPersonService
    {
        public List<Person> Persons { get; set; }
        Task<List<Person>> GetAllPersons();

        Task<Person?> GetPerson(int id);

        Task AddPerson(Person person);

        Task UpdatePerson(int id, Person request);

        Task DeletePerson(int id);
    }
}
