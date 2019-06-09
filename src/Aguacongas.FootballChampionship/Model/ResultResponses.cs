using Aguacongas.AwsServices;

namespace Aguacongas.FootballChampionship.Model
{
    public class ResultResponses
    {
        public AwsGraphQlList<Result> ListResults { get; set; }

        public Result CreateResult { get; set; }
    }
}
