using Microsoft.AspNetCore.Components;
using PracticeProject.Components.DataManipulation;
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
        [Inject]
        private IRelationHandler _relationHandler { get; set; }
        [Inject]
        private DialogService _dialogService { get; set; }

        #endregion

        private RadzenDataGrid<Person>? _personDataGrid;
        private IList<Person> _persons { get; set; }
        private IList<string> _genderList = new List<string>() { "Male", "Female", "Other" };
        private bool _isPersonsLoading;
        private int _personCount;

        private IList<Relation> _relations { get; set; }

        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPageSummary = true;


        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();

            _relations = await _relationHandler.GetAllRelations();
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



        //Open dialog with relations specific for that person - not finished

        //public async Task ViewRelation(Person person)
        //{
        //    await _dialogService.OpenAsync<ViewSpecificRelation>("Edit Relation",
        //        new Dictionary<string, object>() { { "RelationId", person.PersonId } },
        //        new DialogOptions()
        //        {
        //            Width = "700px",
        //            Height = "530px",
        //            Resizable = true,
        //            //Draggable = true,
        //            CloseDialogOnOverlayClick = true,
        //            CloseDialogOnEsc = true,
        //        });
        //}



        //Dialog to confirm removal of a person - does not work completely right yet

        //public async Task ConfirmDeleteDialog()
        //{
        //    await _dialogService.Confirm("Are you sure you want to remove this Person?", "Delete Person",
        //        new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" });

        //    _dialogService.OnClose += CloseConfirmTrash;
        //}

        //private async void CloseConfirmTrash(dynamic result)
        //{
        //    if (result != null) // if the user hits the x near the top right null is returned
        //    {
        //        // result is false if the user clicks no
        //        if ((bool)result) await DeletePerson();
        //    }
        //    Dispose();
        //}

        //private void Dispose()
        //{
        //    _dialogService.OnClose -= CloseConfirmTrash;
        //}


    }
}
