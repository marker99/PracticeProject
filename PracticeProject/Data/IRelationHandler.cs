using PracticeProject.Models;

namespace PracticeProject.Data
{
    public interface IRelationHandler
    {
        public Task<Relation> AddNewRelationBetweenPeople(Relation relation);

    }
}
