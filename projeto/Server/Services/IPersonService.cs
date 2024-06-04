namespace projeto.Server.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllPersons();

        Task<Person?> GetPerson(int id);

        Task<List<Person>> AddPerson(Person person);

        Task<List<Person>?> UpdatePerson(int id, Person request);

        Task<List<Person>?> DeletePerson(int id);
    }
}
