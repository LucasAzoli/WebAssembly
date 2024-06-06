using Microsoft.AspNetCore.Components;
using projeto.Shared.Models;
using System.Net;
using System.Net.Http.Json;

namespace projeto.Client.Service
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public PersonService(HttpClient http, NavigationManager navigationManager) {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Person> Persons { get; set; } = new List<Person>();
        public async Task AddPerson(Person person)
        {
            await _http.PostAsJsonAsync("api/person", person);
            _navigationManager.NavigateTo("persons");
        }

        public async Task DeletePerson(int id)
        {
            await _http.DeleteAsync($"/api/person/{id}");
            _navigationManager.NavigateTo("persons", forceLoad:true);
        }

        public async Task<List<Person>> GetAllPersons()
        {
            var result = await _http.GetFromJsonAsync<List<Person>>("api/Person");
            if (result is not null)
            {
                Persons = result;
            }
            return Persons;
        }

        public async Task<Person?> GetPerson(int id)
        {
            var result = await _http.GetAsync($"api/Person/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Person>();
            }
            return null;
        }

        public async Task UpdatePerson(int id, Person person)
        {
            await _http.PutAsJsonAsync($"/api/person/{id}", person);
            _navigationManager.NavigateTo("persons");
        }
    }
}
