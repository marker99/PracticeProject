using PracticeProject.Models;
using PracticeProject.Repositories;

namespace PracticeProject.Data.Implementations
{
    public class RelationHandler : IRelationHandler
    {
        private IRelationRepository _relationRepository;

        public RelationHandler(IRelationRepository relationRepository)
        {
            _relationRepository = relationRepository;
        }

        public async Task<Relation> AddNewRelationBetweenPeople(Relation relation)
        {
            return await _relationRepository.AddNewRelationBetweenPeopleAsync(relation);
        }

        public async Task<IList<Relation>> GetAllRelations()
        {
            return await _relationRepository.GetAllRelationsAsync();
        }

        public async Task<Relation> GetRelationById(int relationId)
        {
            return await _relationRepository.GetRelationByIdAsync(relationId);
        }

        public async Task RemoveRelation(int id)
        {
            await _relationRepository.RemoveRelationAsync(id);
        }

        public async Task<Relation> UpdateRelation(Relation relation)
        {
            return await _relationRepository.UpdateRelationAsync(relation);
        }
    }
}
