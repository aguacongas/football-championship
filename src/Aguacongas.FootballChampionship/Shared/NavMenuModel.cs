using Aguacongas.FootballChampionship.Localization;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Service;
using Aguacongas.AwsServices;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Shared
{
    public class NavMenuModel : LocalizedComponentBase
    {
        private bool collapseNavMenu = true;

        [Inject]
        public IAwsJsInterop AwsJsInterop { get; set; }

        [Inject]
        public IAwsHelper AwsHelper { get; set; }

        [Inject]
        public ILiveScoreService LiveScoreService { private get; set; }

        protected string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected IEnumerable<Competition> CompetitionList { get; private set; }

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        protected override async Task OnInitAsync()
        {
            var response = await AwsJsInterop.GraphQlAsync<CompetitionList>(Queries.LIST_COMPETITIONS);
            CompetitionList = response.ListCompetitions.Items;

            LiveScoreService.Start(CompetitionList);
        }
    }
}
