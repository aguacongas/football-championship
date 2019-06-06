using Aguacongas.FootballChampionship.Services;

namespace Aguacongas.FootballChampionship.Model
{
    public class ResultResponses
    {
        public AwsGraphQlList<Result> ListResults { get; set; }

        public Result CreateResult { get; set; }
    }
}
