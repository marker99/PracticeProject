using PracticeProject.Database;
using PracticeProject.Models;

namespace PracticeProject.Repositories.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private FamilyDbContext _dbContext;

        public PersonRepository(FamilyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> AddNewPersonAsync(Person person)
        {
            var entityEntry = await _dbContext.Persons.AddAsync(person);
            await _dbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
