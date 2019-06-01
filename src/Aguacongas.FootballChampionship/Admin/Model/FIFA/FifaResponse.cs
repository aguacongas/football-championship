using System.Collections.Generic;

namespace Aguacongas.FootballChampionship.Admin.Model.FIFA
{
    public class FifaResponse<T>
    {
        public string ContinuationToken { get; set; }
        public string ContinuationHash { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}
