using PracticeProject.Models;

namespace PracticeProject.Repositories
{
    public interface IRelationRepository
    {
        public Task<Relation> AddNewRelationBetweenPeopleAsync(Relation relation);

    }
}
