using Aguacongas.FootballChampionship.Localization;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Service;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
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
        public IRankingService RankingService { private get; set; }

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


            Results = await RankingService.ComputeResultList($"{Id}/{Stage}");
            
            Competition = RankingService.Competition;
        }
    }
}
