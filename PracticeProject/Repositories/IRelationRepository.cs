using PracticeProject.Models;

namespace PracticeProject.Repositories
{
    public interface IRelationRepository
    {
        public Task<Relation> AddNewRelationBetweenPeopleAsync(Relation relation);

        public Task<IList<Relation>> GetAllRelationsAsync();

        public Task RemoveRelationAsync(int id);

        public Task<Relation> UpdateRelationAsync(Relation relation);

        public Task<Relation> GetRelationByIdAsync(int relationId);

    }
}
