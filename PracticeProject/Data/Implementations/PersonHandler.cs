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
    }
}
