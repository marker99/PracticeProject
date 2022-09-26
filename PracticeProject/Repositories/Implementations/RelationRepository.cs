using Microsoft.EntityFrameworkCore;
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

        public async Task<IList<Relation>> GetAllRelationsAsync()
        {
            return await _dbContext.Relations.ToListAsync();
        }

        public async Task RemoveRelationAsync(int id)
        {
            Relation relationToDelete = await _dbContext.Relations.FirstOrDefaultAsync(x => x.RelationId == id);
            if (relationToDelete != null)
            {
                _dbContext.Relations.Remove(relationToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
