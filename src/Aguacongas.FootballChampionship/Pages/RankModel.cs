using Aguacongas.FootballChampionship.Localization;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Pages
{
    public class RankModel : ComponentBase
    {
        [Parameter]
        protected string Id { get; set; }

        [Parameter]
        protected string Stage { get; set; }

        [Inject]
        public IAwsJsInterop AwsJsInterop { get; set; }

        [Inject]
        public IResources Resources { get; set; }

        protected Model.Competition Competition { get; private set; }
        protected IEnumerable<Result> Results { get; private set; }

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();

            Resources.CultureChanged += (e, a) =>
            {
                StateHasChanged();
            };

            var rankResponse = await AwsJsInterop.GraphQlAsync<CompetitionResponses>(Queries.LIST_RESULT,
            new
            {
                id = $"{Id}/{Stage}"
            });

            Competition = rankResponse.GetCompetition;
            Results = rankResponse.GetCompetition.Results.Items;
        }
    }
}
