using Microsoft.AspNetCore.Components;
using PracticeProject.Data;
using PracticeProject.Models;

namespace PracticeProject.Components
{
    public partial class AddPersonComponent
    {
        #region Injections

        [Inject]
        private IPersonHandler _personHandler { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }

        #endregion


        public Person newPerson;

        private IList<string> _genderList = new List<string>() { "Male", "Female", "Other" };


        protected override async Task OnInitializedAsync()
        {
            newPerson = new();
        }

        public void AddNewPerson()
        {
            _personHandler.AddNewPerson(newPerson);
            _navigationManager.NavigateTo("/mainPage", true);
        }

        public void Cancel()
        {
            newPerson = new Person
            {
                FirstName = "",
                LastName = "",
                Age = 0,
                Gender = "",
                Address = "",
                PhoneNumber = ""
            };
        }
	}
}
