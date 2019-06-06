using Aguacongas.FootballChampionship.Interop;
using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Services;
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

        public Competition Competition { get; private set; }
        public IEnumerable<Match> Matches { get; private set; }
        public IEnumerable<IGrouping<DateTime, Match>> MatchGroup { get; private set; }

        private bool _createResult;

        public CompetitionService(IAwsJsInterop awsJsInterop,
            IAwsHelper awsHelper,
            IBrowserDateTime browserDateTime)
        {
            _awsJsInterop = awsJsInterop;
            _awsHelper = awsHelper;
            _browserDateTime = browserDateTime;
        }

        public async Task Initialize(string competitionId)
        {
            var competitionResponses = await _awsJsInterop.GraphQlAsync<CompetitionResponses>(Queries.GET_COMPETITION, new { id = competitionId });
            Competition = competitionResponses.GetCompetition;

            var matchesResponseTask = _awsJsInterop.GraphQlAsync<MatchesResponse>(Queries.LIST_MATCH,
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

            var betsResponseTask = _awsJsInterop.GraphQlAsync<BetResponses>(Queries.LIST_BET,
            new
            {
                Filter = new
                {
                    Owner = new
                    {
                        Eq = _awsHelper.User.Username
                    },
                    And = new
                    {
                        BetCompetitionId = new
                        {
                            Eq = competitionId
                        }
                    }
                },
                Limit = 1000
            });

            var resultResponseTask = _awsJsInterop.GraphQlAsync<ResultResponses>(Queries.LIST_RESULT,
            new
            {                
                Filter = new
                {
                    Owner = new
                    {
                        Eq = _awsHelper.User.Username
                    },
                    And = new
                    {
                        ResultCompetitionId = new
                        {
                            Eq = competitionId
                        }
                    }
                }            
            });

            await Task.WhenAll(matchesResponseTask, betsResponseTask, resultResponseTask);
            var matchesResponse = matchesResponseTask.Result;

            Matches = matchesResponse.ListMatchs.Items;

            var betsResponse = betsResponseTask.Result;
            var betsScore = betsResponse.ListBets.Items.Select(b => new BetScore
            {
                Id = b.Id,
                MatchId = b.Match.Id,
                HomeValue = b.Scores.FirstOrDefault(s => s.IsHome)?.Value,
                AwayValue = b.Scores.FirstOrDefault(s => !s.IsHome)?.Value
            });

            foreach (var match in Matches)
            {
                var betScore = betsScore.FirstOrDefault(b => b.MatchId == match.Id) ?? new BetScore
                {
                    MatchId = match.Id
                };
                betScore.ValueChanged = false;
                match.Bet = betScore;
                match.BeginAtLocal = await _browserDateTime.ToBrowerTime(match.BeginAt);
            }

            MatchGroup = Matches
                .OrderBy(m => m.BeginAt)
                .GroupBy(m => m.BeginAt.Date);

            _createResult = !resultResponseTask.Result.ListResults.Items.Any();
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
    }
}
