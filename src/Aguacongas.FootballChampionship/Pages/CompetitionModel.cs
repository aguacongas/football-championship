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
        public IAwsHelper AwsHelper { private get; set; }

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

            var matchesResponseTask = AwsJsInterop.GraphQlAsync<MatchesResponse>(Queries.LIST_MATCH,
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

            var betsResponseTask = AwsJsInterop.GraphQlAsync<BetResponses>(Queries.LIST_BET,
            new
            {
                Filter = new
                {
                    Owner = new
                    {
                        Eq = AwsHelper.User.Username
                    },
                    And = new
                    {
                        CompetitionId = new
                        {
                            Eq = competitionId
                        }
                    }
                },
                Limit = 1000
            });

            await Task.WhenAll(matchesResponseTask, betsResponseTask);
            var matchesResponse = matchesResponseTask.Result;            
            var betsResponse = betsResponseTask.Result;

            var matches = matchesResponse.ListMatchs.Items;
            MatchGroup = matches
                .OrderBy(m => m.BeginAt)
                .GroupBy(m => m.BeginAt.Date);

            var betsScore = betsResponse.ListBets.Items.Select(b => new BetScore
            {
                Id = b.Id,
                MatchId = b.Match.Id,
                HomeValue = b.Scores.FirstOrDefault(s => s.IsHome)?.Value,
                AwayValue = b.Scores.FirstOrDefault(s => !s.IsHome)?.Value
            });

            foreach (var match in matches)
            {
                match.Bet = betsScore.FirstOrDefault(b => b.MatchId == match.Id) ?? new BetScore
                {
                    MatchId = match.Id
                };
            }

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

        protected async Task SaveBet(BetScore bet)
        {
            await AwsJsInterop.GraphQlAsync<object>(bet.Id == null ? Mutations.CREATE_BET : Mutations.UPDATE_BET, new
            {
                input = new
                {
                    owner = AwsHelper.User.Username,
                    userName = AwsHelper.UserName,
                    competitionId = Competition.Id,
                    betMatchId = bet.MatchId,
                    scores = new object[]
                    {
                        new
                        {
                            isHome = true,
                            value = bet.HomeValue
                        },
                        new
                        {
                            isHome = false,
                            value = bet.AwayValue
                        }
                    }
                }
            });
        }

        protected bool CanBet(Match match)
        {
            return DateTimeOffset.Now < match.BeginAt &&
                (match.Scores == null || !match.Scores.Any());
        }
    }
}
