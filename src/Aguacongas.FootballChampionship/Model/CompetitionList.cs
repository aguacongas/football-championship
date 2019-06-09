using Aguacongas.AwsServices;

namespace Aguacongas.FootballChampionship.Model
{
    public class CompetitionList
    {
        public AwsGraphQlList<Competition> ListCompetitions { get; set; }
    }
}
