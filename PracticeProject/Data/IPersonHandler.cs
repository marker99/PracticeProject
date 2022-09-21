using PracticeProject.Models;

namespace PracticeProject.Data
{
    public interface IPersonHandler
    {
        public Task<Person> AddNewPerson(Person person);

    }
}
