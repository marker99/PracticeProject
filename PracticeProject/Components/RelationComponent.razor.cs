using PracticeProject.Models;

namespace PracticeProject.Components
{
    public partial class RelationComponent
    {
        public Person person;


        public IEnumerable<Person> people;

        public Relation newRelation;

        protected override async Task OnInitializedAsync()
        {
            person = new();
            newRelation = new();
        }

        public void AddNewRelation()
        {

        }

        public void Cancel()
        {
            //do something
        }
    }
}

