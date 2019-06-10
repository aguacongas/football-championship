using Aguacongas.FootballChampionship.Interop;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.AwsServices;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Service
{
    public class CompetitionService : ICompetitionService
    {
        private readonly IAwsJsInterop _awsJsInterop;
        private readonly IAwsHelper _awsHelper;
        private readonly IBrowserDateTime _browserDateTime;
        private readonly IBrowserJsInterop _browserJsInterop;

        private bool _hasScrolled;

        public Competition Competition { get; private set; }
        public IEnumerable<Match> Matches { get; private set; }
        public IEnumerable<IGrouping<DateTime, Match>> MatchGroup { get; private set; }

        private bool _createResult;

        public CompetitionService(IAwsJsInterop awsJsInterop,
            IAwsHelper awsHelper,
            IBrowserDateTime browserDateTime,
            IBrowserJsInterop browserJsInterop)
        {
            _awsJsInterop = awsJsInterop;
            _awsHelper = awsHelper;
            _browserDateTime = browserDateTime;
            _browserJsInterop = browserJsInterop;
        }

        public async Task Initialize(string competitionId)
        {
            var competitionResponses = await _awsJsInterop.GraphQlAsync<CompetitionResponses>(Queries.GET_COMPETITION,
                new
                {
                    id = competitionId,
                    owner = _awsHelper.User.Username
                });

            Competition = competitionResponses.GetCompetition;

            _createResult = !Competition.Results.Items.Any();

            Matches = Competition.Matches.Items;

            foreach (var match in Matches)
            {
                var bet = match.Bets.Items.FirstOrDefault();
                var betScore = new BetScore
                {
                    Id = bet?.Id,
                    MatchId = match.Id,
                    HomeValue = bet?.Scores.FirstOrDefault(s => s.IsHome)?.Value,
                    AwayValue = bet?.Scores.FirstOrDefault(s => !s.IsHome)?.Value
                };
                betScore.ValueChanged = false;
                match.Bet = betScore;
                match.BeginAtLocal = await _browserDateTime.ToBrowerTime(match.BeginAt);
            }

            MatchGroup = Matches
                .OrderBy(m => m.BeginAt)
                .GroupBy(m => m.BeginAt.Date);
        }

        public async Task SaveBet(BetScore bet)
        {
            var match = Matches.First(m => m.Id == bet.MatchId);
            if (match.BeginAt < DateTime.Now)
            {
                return;
            }

            await _awsJsInterop.GraphQlAsync<object>(bet.Id == null ? Mutations.CREATE_BET : Mutations.UPDATE_BET, new
            {
                input = new
                {
                    id = bet.Id,
                    owner = _awsHelper.User.Username,
                    userName = _awsHelper.UserName,
                    betCompetitionId = Competition.Id,
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

            if (_createResult)
            {
                await _awsJsInterop.GraphQlAsync<ResultResponses>(Mutations.CREATE_RESULT, new
                {
                    input = new
                    {
                        owner = _awsHelper.User.Username,
                        userName = _awsHelper.UserName,
                        resultCompetitionId = Competition.Id,
                        value = 0
                    }
                });
                _createResult = false;
            }

            bet.ValueChanged = false;
            bet.Saved = true;
        }

        public async Task ScrollToDate()
        {
            if (MatchGroup == null || _hasScrolled)
            {
                return;
            }
            var now = DateTime.Now;
            var nextMatch = MatchGroup.FirstOrDefault(m => m.Key.Date >= now.Date);
            if (nextMatch == null)
            {
                nextMatch = MatchGroup.Last();
            }

            _hasScrolled = await _browserJsInterop.ScrollElementIntoView($"day{nextMatch.Key.ToAwsDate()}");
        }
    }
}