using PracticeProject.Models;

namespace PracticeProject.Repositories
{
    public interface IPersonRepository
    {
        public Task<Person> AddNewPersonAsync(Person person);

        public Task<IList<Person>> GetAllPersonsAsync();

        public Task RemovePersonAsync(int id);

        public Task<Person> UpdatePersonAsync(Person person);


        //Ignore this. Just used for adding some dummy data
        void CreatePeopleAndPopulateDb();

    }
}
