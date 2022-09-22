using PracticeProject.Models;
using PracticeProject.Repositories;

namespace PracticeProject.Data.Implementations
{
    public class RelationHandler : IRelationHandler
    {
        private IRelationRepository _relationRepository;

        public async Task<Relation> AddNewRelationBetweenPeople(Relation relation)
        {
            return await _relationRepository.AddNewRelationBetweenPeopleAsync(relation);
        }
    }
}
