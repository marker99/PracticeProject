using PracticeProject.Models;

namespace PracticeProject.Repositories
{
    public interface IPersonRepository
    {
        public Task<Person> AddNewPersonAsync(Person person);

        public Task<IList<Person>> GetAllPersonsAsync();

        //Just used for adding some dummy data
        void CreatePeopleAndPopulateDb();

    }
}
