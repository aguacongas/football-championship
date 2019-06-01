using Aguacongas.FootballChampionship.Services;

namespace Aguacongas.FootballChampionship.Model
{
    public class MatchesResponse
    {
        public AwsGraphQlList<Match> ListMatchs { get; set; }
    }
}
