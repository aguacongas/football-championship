using Aguacongas.FootballChampionship.Localization;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Services;
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

        protected override  async Task OnInitAsync()
        {
            var response = await AwsJsInterop.GraphQlAsync<CompetitionList>(Queries.LIST_COMPETITIONS,
                new
                {
                    Filter = new
                    {
                        To = new
                        {
                            Ge = DateTimeOffset.Now.Date
                        }
                    }
                });
            CompetitionList = response.ListCompetitions.Items;
        }
    }
}
