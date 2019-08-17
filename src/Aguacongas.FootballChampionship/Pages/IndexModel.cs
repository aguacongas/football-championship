using Aguacongas.AwsServices;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Pages
{
    public class IndexModel : LocalizedComponentBase
    {
        [Inject]
        public IAwsJsInterop AwsJsInterop { get; set; }

        [Inject]
        public IUriHelper UriHelper { get; set; }

        protected IEnumerable<Model.Competition> CompetitionList { get; private set; }

        protected override  async Task OnInitializedAsync()
        {
            var response = await AwsJsInterop.GraphQlAsync<CompetitionList>(Queries.LIST_COMPETITIONS);
            CompetitionList = response.ListCompetitions.Items;
        }
    }
}
