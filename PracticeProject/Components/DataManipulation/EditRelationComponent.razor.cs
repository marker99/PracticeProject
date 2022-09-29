using Microsoft.AspNetCore.Components;
using PracticeProject.Data;
using PracticeProject.Models;
using System.Diagnostics;

namespace PracticeProject.Components.DataManipulation
{
    public partial class EditRelationComponent
    {
        #region Injections

        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private IPersonHandler _personHandler { get; set; }
        [Inject]
        private IRelationHandler _relationHandler { get; set; }

        #endregion

        [Parameter]
        public int RelationId { get; set; }

        //private Person _person;
        private IEnumerable<Person> _persons = Enumerable.Empty<Person>();
        //private IEnumerable<Relation> _relations = Enumerable.Empty<Relation>();

        private Relation _relation;

        protected override async Task OnInitializedAsync()
        {
            //_person = new();
            _relation = new Relation();

            _persons = await _personHandler.GetAllPersons();
            //_relations = await _relationHandler.GetAllRelations();
            _relation = await _relationHandler.GetRelationById(RelationId);

        }

        public async Task UpdateRelation()
        {
            await _relationHandler.UpdateRelation(_relation);
            _navigationManager.NavigateTo("/mainPage", true);
        }

        public void OnChange(object value, string name)
        {
            Debug.WriteLine($"{name} value changed to {_relation.PersonId2}");
        }

        public void Cancel()
        {
            _navigationManager.NavigateTo("/family");
        }

    }
}
