using Aguacongas.FootballChampionship.Model;
using System.Collections.Generic;
using System.Linq;

namespace Aguacongas.FootballChampionship
{
    public static class ScoreExtensions
    {
        public static int ComputeResult(this IEnumerable<Score> scores, IEnumerable<Score> bets)
        {
            var homeBet = bets.First(s => s.IsHome).Value;
            var awayBet = bets.First(s => !s.IsHome).Value;
            return ComputeResult(scores, homeBet, awayBet);
        }

        public static int ComputeResult(this IEnumerable<Score> scores, int homeBet, int awayBet)
        {
            var homeScore = scores.First(s => s.IsHome).Value;
            var awayScore = scores.First(s => !s.IsHome).Value;

            if (homeScore == homeBet && awayScore == awayBet)
            {
                return 3;
            }

            if (homeScore == awayScore && homeBet == awayBet)
            {
                return 1;
            }

            if (homeScore > awayScore && homeBet > awayBet)
            {
                return 1;
            }

            if (homeScore < awayScore && homeBet < awayBet)
            {
                return 1;
            }

            return 0;
        }
    }
}
