using Microsoft.EntityFrameworkCore;
using PracticeProject.Models;
using Radzen;
using Radzen.Blazor;

namespace PracticeProject.Components
{
    public partial class PeopleComponent
    {
        int count;
        private IList<Person> _persons { get; set; }

        private Person _person { get; set; }
        private IList<string> _genderList = new List<string>() { "Male", "Female", "Other" };


        RadzenDataGrid<Person>? _dataGrid;

        private bool isPersonsLoading;

        private IList<Relation> _relationships { get; set; }

        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPageSummary = true;

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
        }

        async Task LoadPersonData(LoadDataArgs args)
        {
            isPersonsLoading = true;

            await Task.Yield();

            _persons = await _personHandler.GetAllPersons();
            count = _persons.Count();

            isPersonsLoading = false;

            StateHasChanged();
        }


        public async Task UpdatePerson(Person person)
        {
            await _personHandler.UpdatePerson(person);
        }
        
        public async Task SaveRow(Person person)
        {
            await _dataGrid.UpdateRow(person);
        }

        async Task DeletePerson(int id)
        {
            await _personHandler.RemovePerson(id);

            await _dataGrid.Reload();
        }

        public async Task EditPerson(Person person)
        {
            await _dataGrid.EditRow(person);
        }

        public void CancelEdit(Person person)
        {
            _dataGrid.CancelEditRow(person);
        }

    }
}
