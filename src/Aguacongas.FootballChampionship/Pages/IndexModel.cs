using Aguacongas.FootballChampionship.Components;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Pages
{
    public class IndexModel : ComponentBase
    {
        [Inject]
        public AwsJsInterop AwsJsInterop { get; set; }

        protected IEnumerable<Competition> CompetionList { get; private set; }

        protected override  async Task OnInitAsync()
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
            CompetionList = response.ListCompetitions.Items;
        }
    }
}
