using PracticeProject.Models;

namespace PracticeProject.Components
{
    public partial class AddPersonComponent
    {
        public Person newPerson;

        private IList<string> _genderList = new List<string>() { "Male", "Female", "Other" };


        protected override async Task OnInitializedAsync()
        {
            newPerson = new();
        }

        public void AddNewPerson()
        {
            _personHandler.AddNewPerson(newPerson);
            _navMgr.NavigateTo("/family");
        }

        public void Cancel()
        {
            //do something
        }
	}
}
