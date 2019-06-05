using Aguacongas.FootballChampionship.Localization;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Shared
{
    public class NavMenuModel : ComponentBase
    {
        private bool collapseNavMenu = true;

        [Inject]
        public IAwsJsInterop AwsJsInterop { get; set; }

        [Inject]
        public IAwsHelper AwsHelper { get; set; }

        [Inject]
        public IResources Resources { get; set; }

        protected string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected IEnumerable<Competition> CompetitionList { get; private set; }

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        protected override async Task OnInitAsync()
        {
            var response = await AwsJsInterop.GraphQlAsync<CompetitionList>(Queries.LIST_COMPETITIONS,
                new
                {
                    Filter = new
                    {
                        From = new
                        {
                            Ge = DateTimeOffset.Now
                        }
                    }
                });
            CompetitionList = response.ListCompetitions.Items;

            Resources.CultureChanged += (e, a) =>
            {
                StateHasChanged();
            };
        }
    }
}
