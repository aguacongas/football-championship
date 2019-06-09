using Aguacongas.FootballChampionship.Localization;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Service;
using Aguacongas.FootballChampionship.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Pages
{
    public class RankModel : LocalizedComponentBase
    {
        [Parameter]
        protected string Id { get; set; }

        [Parameter]
        protected string Stage { get; set; }

        [Inject]
        public IRankingService RankingService { private get; set; }

        protected Model.Competition Competition { get; private set; }
        protected IEnumerable<Result> Results { get; private set; }

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();

            Results = await RankingService.ComputeResultList($"{Id}/{Stage}");
            
            Competition = RankingService.Competition;
        }
    }
}
