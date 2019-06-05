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
    public class CompetitionModel : ComponentBase
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

        protected IEnumerable<IGrouping<DateTime, Match>> MatchGroup { get; private set; }

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();

            var competitionId = $"{Id}/{Stage}";
            var competitionResponses = await AwsJsInterop.GraphQlAsync<CompetitionResponses>(Queries.GET_COMPETITION, new { id = competitionId });
            Competition = competitionResponses.GetCompetition;
            var matchesResponse = await AwsJsInterop.GraphQlAsync<MatchesResponse>(Queries.LIST_MATCH,
            new
            {
                Filter = new
                {
                    MatchCompetitionId = new
                    {
                        Eq = competitionId
                    }
                },
                Limit = 1000
            });
            MatchGroup = matchesResponse.ListMatchs.Items
                .OrderBy(m => m.BeginAt)
                .GroupBy(m => m.BeginAt.Date);

            Resources.CultureChanged += (e, a) =>
            {
                StateHasChanged();
            };
        }

        protected string GetTeamName(Match match, bool isHome)
        {
            var matchTeam = match.MatchTeams.Items.FirstOrDefault(m => m.IsHome == isHome);
            if (matchTeam != null)
            {
                return matchTeam.Team.LocalizedNames.GetLocalizedValue();
            }

            if (isHome)
            {
                return match.PlaceHolderHome;
            }

            return match.PlaceHolderAway;
        }
    }
}
