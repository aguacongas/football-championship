using System.Collections.Generic;

namespace Aguacongas.AwsServices
{
    public class AwsGraphQlList<T>
    {
        public IEnumerable<T> Items { get; set; }

        public string NextToken { get; set; }
    }
}
