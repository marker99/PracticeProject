using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PracticeProject.Models;

namespace PracticeProject.Data
{
    public interface IPersonHandler
    {
        public Task<Person> AddNewPerson(Person person);

        public Task<IList<Person>> GetAllPersons();

        public Task<Person> GetPersonByIdAsync(int personId);
        
        public Task RemovePerson(int id);

        public Task<Person> UpdatePerson(Person person);

    }
}
