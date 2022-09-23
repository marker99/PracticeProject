using PracticeProject.Models;
using PracticeProject.Repositories;

namespace PracticeProject.Data.Implementations
{
    public class PersonHandler : IPersonHandler
    {
        private IPersonRepository _personRepository;

        public PersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> AddNewPerson(Person person)
        {
            return await _personRepository.AddNewPersonAsync(person);
        }

        public async Task<IList<Person>> GetAllPersons()
        {
            return await _personRepository.GetAllPersonsAsync();
        }

        public async Task RemovePerson(int id)
        {
            await _personRepository.RemovePersonAsync(id);
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            return await _personRepository.UpdatePersonAsync(person);
        }
    }
}
