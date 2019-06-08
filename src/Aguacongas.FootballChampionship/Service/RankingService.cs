using Aguacongas.FootballChampionship.Model;
using Aguacongas.FootballChampionship.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Service
{
    public class RankingService : IRankingService
    {
        private readonly IAwsJsInterop _awsJsInterop;

        public Competition Competition { get; private set; }

        public RankingService(IAwsJsInterop awsJsInterop)
        {
            _awsJsInterop = awsJsInterop;
        }

        public async Task<IEnumerable<Result>> ComputeResultList(string competitionId)
        {
            var competitionResponse = await _awsJsInterop.GraphQlAsync<CompetitionResponses>(Queries.GET_COMPETITION_WITH_RESULTS,
                new
                {
                    id = competitionId
                });

            Competition = competitionResponse.GetCompetition;
            var matches = Competition.Matches.Items;
            var resultList = new List<Result>();
            foreach (var match in matches)
            {
                if (match.Scores == null || !match.Scores.Any())
                {
                    continue;
                }

                foreach (var bet in match.Bets.Items)
                {
                    if (bet.Scores == null || !bet.Scores.Any())
                    {
                        continue;
                    }
                    var result = resultList.FirstOrDefault(r => r.Owner == bet.Owner);
                    if (result == null)
                    {
                        result = new Result
                        {
                            Owner = bet.Owner,
                            UserName = bet.UserName
                        };
                        resultList.Add(result);
                    }

                    result.Value += match.Scores.ComputeResult(bet.Scores);
                }
            }

            return resultList.OrderByDescending(r => r.Value);
        }
    }
}
