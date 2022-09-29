using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PracticeProject.Database;
using PracticeProject.Models;

namespace PracticeProject.Repositories.Implementations
{
    public class RelationRepository : IRelationRepository
    {
        private readonly IDbContextFactory<FamilyDbContext> _contextFactory;

        public RelationRepository(IDbContextFactory<FamilyDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Relation> AddNewRelationBetweenPeopleAsync(Relation relation)
        {
            await using var context = _contextFactory.CreateDbContext();
            //await using var transaction = context.Database.BeginTransaction();

            //context.Database.Exe


            var entityEntry = await context.Relations.AddAsync(relation);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<IList<Relation>> GetAllRelationsAsync()
        {
            await using var context = _contextFactory.CreateDbContext();

            return await context.Relations.ToListAsync();
        }

        public async Task<Relation> GetRelationByIdAsync(int relationId)
        {
            await using var context = _contextFactory.CreateDbContext();

            return await context.Relations.FirstOrDefaultAsync(r => r.RelationId == relationId);
        }

        public async Task RemoveRelationAsync(int id)
        {
            await using var context = _contextFactory.CreateDbContext();

            Relation relationToDelete = await context.Relations.FirstOrDefaultAsync(x => x.RelationId == id);
            if (relationToDelete != null)
            {
                context.Relations.Remove(relationToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Relation> UpdateRelationAsync(Relation relation)
        {
            await using var context = _contextFactory.CreateDbContext();

            EntityEntry<Relation> entity = context.Update(relation);
            await context.SaveChangesAsync();

            return entity.Entity;
        }
    }
}
