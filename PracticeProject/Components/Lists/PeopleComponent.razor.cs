using Microsoft.AspNetCore.Components;
using PracticeProject.Data;
using PracticeProject.Models;
using Radzen;
using Radzen.Blazor;

namespace PracticeProject.Components.Lists
{
    public partial class PeopleComponent
    {
        #region Injections

        [Inject]
        private IPersonHandler _personHandler { get; set; }

        #endregion

        private RadzenDataGrid<Person>? _personDataGrid;
        private IList<Person> _persons { get; set; }
        private IList<string> _genderList = new List<string>() { "Male", "Female", "Other" };
        private bool _isPersonsLoading;
        private int _personCount;

        //Relation fields should be moved here

        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPageSummary = true;


        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
        }

        public async Task LoadPersonData(LoadDataArgs args)
        {
            _isPersonsLoading = true;
            await Task.Yield();

            _persons = await _personHandler.GetAllPersons();
            
            _personCount = _persons.Count();

            _isPersonsLoading = false;

            StateHasChanged();
        }

        public async Task UpdatePerson(Person person)
        {
            await _personHandler.UpdatePerson(person);
        }

        public async Task DeletePerson(int id)
        {
            await _personHandler.RemovePerson(id);

            await _personDataGrid.Reload();
        }

        public async Task SaveRow(Person person)
        {
            await _personDataGrid.UpdateRow(person);
        }

        public async Task EditPerson(Person person)
        {
            await _personDataGrid.EditRow(person);
        }

        public void CancelEdit(Person person)
        {
            _personDataGrid.CancelEditRow(person);
        }

    }
}
