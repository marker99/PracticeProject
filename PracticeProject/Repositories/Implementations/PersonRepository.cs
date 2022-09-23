using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<IList<Person>> GetAllPersonsAsync()
        {
            return await _dbContext.Persons.ToListAsync();
        }

        public async Task RemovePersonAsync(int id)
        {
            Person personToDelete = _dbContext.Persons.FirstOrDefault(x => x.PersonId == id);
            if (personToDelete != null)
            {
                _dbContext.Persons.Remove(personToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<Person> UpdatePersonAsync(Person person)
        {
            EntityEntry<Person> entity = _dbContext.Persons.Update(person);
            await _dbContext.SaveChangesAsync();

            return entity.Entity;
        }


        //Ignore this. Just used for adding some dummy data
        public void CreatePeopleAndPopulateDb()
        {
            var existingPeople = _dbContext.Persons.Select(x => x);
            _dbContext.Persons.RemoveRange(existingPeople);

            var peopleList = new List<Person>()
            {
                new Person
                {
                    FirstName = "Sebastian",
                    LastName = "Thomsen",
                    Age = 25,
                    Gender = "Male",
                    Address = "Hybenvej 23",
                    PhoneNumber = "85639844"
                },
                new Person
                {
                    FirstName = "Sander",
                    LastName = "Kikkert",
                    Age = 26,
                    Gender = "Male",
                    Address = "Juvelvej 3",
                    PhoneNumber = "11102244"
                },
                new Person
                {
                    FirstName = "Anne",
                    LastName = "Jensen",
                    Age = 21,
                    Gender = "Female",
                    Address = "Nordrevej 10",
                    PhoneNumber = "10508326"
                },
                new Person
                {
                    FirstName = "Julie",
                    LastName = "Jensen",
                    Age = 19,
                    Gender = "Female",
                    Address = "Nordrevej 10",
                    PhoneNumber = "74061648"
                },
                new Person
                {
                    FirstName = "Jørgen",
                    LastName = "Jensen",
                    Age = 55,
                    Gender = "Male",
                    Address = "Nordrevej 10",
                    PhoneNumber = "99547720"
                },
                new Person
                {
                    FirstName = "Gitte",
                    LastName = "Madsen",
                    Age = 53,
                    Gender = "Female",
                    Address = "Nordrevej 10",
                    PhoneNumber = "66128823"
                }

            };

            foreach (Person person in peopleList)
            {
                _dbContext.AddAsync(person);
            }

            _dbContext.SaveChangesAsync();
        }


    }
}
