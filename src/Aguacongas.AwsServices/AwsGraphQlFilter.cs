using System.Collections.Generic;

namespace Aguacongas.AwsServices
{
    public class AwsGraphQlScalarFilter
    {
        public string Ne { get; set; }

        public string Eq { get; set; }

        public string Le { get; set; }

        public string Lt { get; set; }

        public string Ge { get; set; }

        public string Gt { get; set; }

        public string Contains { get; set; }

        public string NotContains { get; set; }

        public IEnumerable<string> Between { get; set; }

        public string BeginsWith { get; set; }
    }
    public class AwsGraphQlScalarFilter<T> where T: struct
    {
        public T? Ne { get; set; }

        public T? Eq { get; set; }

        public T? Le { get; set; }

        public T? Lt { get; set; }

        public T? Ge { get; set; }

        public T? Gt { get; set; }

        public T? Contains { get; set; }

        public T? NotContains { get; set; }

        public IEnumerable<T> Between { get; set; }

        public T? BeginsWith { get; set; }
    }

    public interface IAwsGraphQlBaseFilter<T>
    {
        IAwsGraphQlBaseFilter<T> And { get; set; }

        IAwsGraphQlBaseFilter<T> Or { get; set; }

        IAwsGraphQlBaseFilter<T> Not { get; set; }
    }

    public abstract class AwsGraphQlBaseFilter<TFilter, TType>: IAwsGraphQlBaseFilter<TType> where TFilter: IAwsGraphQlBaseFilter<TType>
    {
        public TFilter And { get; set; }

        public TFilter Or { get; set; }

        public TFilter Not { get; set; }
        IAwsGraphQlBaseFilter<TType> IAwsGraphQlBaseFilter<TType>.And { get => And; set => And = (TFilter)value; }
        IAwsGraphQlBaseFilter<TType> IAwsGraphQlBaseFilter<TType>.Or { get => Or; set => Or = (TFilter)value; }
        IAwsGraphQlBaseFilter<TType> IAwsGraphQlBaseFilter<TType>.Not { get => Not; set => Not = (TFilter)value; }
    }
}
