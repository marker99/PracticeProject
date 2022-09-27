using PracticeProject.Models;

namespace PracticeProject.Data
{
    public interface IRelationHandler
    {
        public Task<Relation> AddNewRelationBetweenPeople(Relation relation);

        public Task<IList<Relation>> GetAllRelations();

        public Task RemoveRelation(int id);

        public Task<Relation> UpdateRelation(Relation relation);

        public Task<Relation> GetRelationById(int relationId);
    }
}
