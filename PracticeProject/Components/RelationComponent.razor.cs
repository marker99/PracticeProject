using PracticeProject.Models;

namespace PracticeProject.Components
{
    public partial class RelationComponent
    {
        //private Person _person;
        private IList<Person> _persons;


        private Relation _newRelation;

        protected override async Task OnInitializedAsync()
        {
            _persons = await _personHandler.GetAllPersons();
            //_person = new();
            _newRelation = new();
            
        }

        public void AddNewRelation()
        {
            _relationHandler.AddNewRelationBetweenPeople(_newRelation);
        }

        public void Cancel()
        {
            //do something
        }
    }
}

