using PracticeProject.Database;
using PracticeProject.Models;

namespace PracticeProject.Repositories.Implementations
{
    public class RelationRepository : IRelationRepository
    {
        private FamilyDbContext _dbContext;

        public RelationRepository(FamilyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Relation> AddNewRelationBetweenPeopleAsync(Relation relation)
        {
            var entityEntry = await _dbContext.Relations.AddAsync(relation);
            await _dbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
