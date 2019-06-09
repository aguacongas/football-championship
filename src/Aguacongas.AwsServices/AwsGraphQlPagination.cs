namespace Aguacongas.AwsServices
{
    public class AwsGraphQlPagination<TFilter, TType> where TFilter: IAwsGraphQlBaseFilter<TType>
    {
        public TFilter Filter { get; set; }

        public int? Limit { get; set; }

        public string NextToken { get; set; }
    }
}
