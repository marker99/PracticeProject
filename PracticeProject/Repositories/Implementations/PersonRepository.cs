using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PracticeProject.Database;
using PracticeProject.Models;

namespace PracticeProject.Repositories.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDbContextFactory<FamilyDbContext> _contextFactory;


        public PersonRepository(IDbContextFactory<FamilyDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Person> AddNewPersonAsync(Person person)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            var entityEntry = await context.Persons.AddAsync(person);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<IList<Person>> GetAllPersonsAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            return await context.Persons
                .Include(x => x.Person1Relations)
                .Include(x => x.Person2Relations)
                .ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int personId)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            return await context.Persons.FirstOrDefaultAsync(p => p.PersonId == personId);
        }

        public async Task RemovePersonAsync(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            Person personToDelete = await context.Persons.FirstOrDefaultAsync(x => x.PersonId == id);
            if (personToDelete != null)
            {
                context.Persons.Remove(personToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Person> UpdatePersonAsync(Person person)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            EntityEntry<Person> entity = context.Persons.Update(person);
            await context.SaveChangesAsync();

            return entity.Entity;
        }


        //Ignore this. Just used for adding some dummy data
        public void CreatePeopleAndPopulateDb()
        {
            using var context = _contextFactory.CreateDbContext();
            {
                var existingRelations = context.Relations.Select(x => x);
                context.Relations.RemoveRange(existingRelations);

                var existingPeople = context.Persons.Select(x => x);
                context.Persons.RemoveRange(existingPeople);

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
                },
                new Person
                {
                    FirstName = "Kirsten",
                    LastName = "Madsen",
                    Age = 22,
                    Gender = "Female",
                    Address = "Nordlystvej 11",
                    PhoneNumber = "11667397"
                },
                new Person
                {
                    FirstName = "Peter",
                    LastName = "Kjaergaard",
                    Age = 24,
                    Gender = "Male",
                    Address = "Østergade 18",
                    PhoneNumber = "94258612"
                },
                new Person
                {
                    FirstName = "Jonas",
                    LastName = "Gammelby",
                    Age = 24,
                    Gender = "Male",
                    Address = "Fasanvej 8",
                    PhoneNumber = "23751277"
                }


            };

                foreach (Person person in peopleList)
                {
                    context.AddAsync(person);
                }

                context.SaveChangesAsync();
            }


        }


    }
}
