using PracticeProject.Models;

namespace PracticeProject.Repositories
{
    public interface IPersonRepository
    {
        public Task<Person> AddNewPersonAsync(Person person);
    }
}
