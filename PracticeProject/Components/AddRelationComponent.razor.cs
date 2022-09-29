using Microsoft.AspNetCore.Components;
using PracticeProject.Data;
using PracticeProject.Models;
using System;

namespace PracticeProject.Components
{
    public partial class AddRelationComponent
    {
        #region Injections

        [Inject]
        private NavigationManager navigationManager { get; set; }
        [Inject]
        public IPersonHandler _personHandler { get; set; }
        [Inject]
        public IRelationHandler _relationHandler { get; set; }

        #endregion

        //private Person _person;
        private IEnumerable<Person> _persons = Enumerable.Empty<Person>();

        private Relation _newRelation;

        protected override async Task OnInitializedAsync()
        {
            //_person = new();
            _newRelation = new Relation();

            _persons = await _personHandler.GetAllPersons();

        }

        public void AddNewRelation()
        {
            _relationHandler.AddNewRelationBetweenPeople(_newRelation);
            navigationManager.NavigateTo("/mainPage", true);

        }

        public void Cancel()
        {
            _newRelation = new Relation();
        }
    }
}

