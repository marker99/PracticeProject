using PracticeProject.Models;

namespace PracticeProject.Components
{
    public partial class PeopleComponent
    {
        private IList<Person> _persons { get; set; }
        private IList<Relation> _relationships { get; set; }

        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPageSummary = true;

        protected override async Task OnInitializedAsync()
        {
            _persons = await _personHandler.GetAllPersons();
        }
    }
}
