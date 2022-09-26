using Microsoft.AspNetCore.Components;
using PracticeProject.Data;
using PracticeProject.Models;
using Radzen.Blazor;
using Radzen;

namespace PracticeProject.Components
{
    public partial class RelationsComponent
    {
        #region Injections

        [Inject]
        private IRelationHandler _relationHandler { get; set; }

        #endregion

        private RadzenDataGrid<Relation>? _relationDataGrid;
        private IList<Relation> _relations { get; set; }
        private bool _isRelationsLoading;
        private int _relationsCount;

        string pagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        bool showPageSummary = true;

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
        }

        public async Task LoadRelationData(LoadDataArgs args)
        {
            _isRelationsLoading = true;
            await Task.Yield();

            _relations = await _relationHandler.GetAllRelations();
            _relationsCount = _relations.Count();

            _isRelationsLoading = false;

            StateHasChanged();
        }

        public async Task DeleteRelation(int id)
        {
            await _relationHandler.RemoveRelation(id);
            await _relationDataGrid.Reload();
        }


    }
}
