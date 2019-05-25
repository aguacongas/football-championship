using System.Collections.Generic;

namespace Aguacongas.FootballChampionship.Services
{
    public class AwsGraphQlList<T>
    {
        public IEnumerable<T> Items { get; set; }

        public string NextToken { get; set; }
    }
}
