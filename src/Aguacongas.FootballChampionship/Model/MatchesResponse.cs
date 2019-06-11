using Aguacongas.AwsServices;

namespace Aguacongas.FootballChampionship.Model
{
    public class MatchesResponse
    {
        public AwsGraphQlList<Match> ListMatchs { get; set; }

        public Match GetMatch { get; set; }
    }
}
