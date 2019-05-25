using Aguacongas.FootballChampionship.Services;
using System;

namespace Aguacongas.FootballChampionship.Model
{
    public class CompetitionFilter: AwsGraphQlBaseFilter<CompetitionFilter, Competition>
    {
        public AwsGraphQlScalarFilter Id { get; set; }

        public AwsGraphQlScalarFilter Title { get; set; }

        public AwsGraphQlScalarFilter<DateTime> From { get; set; }

        public AwsGraphQlScalarFilter<DateTime> To { get; set; }
    }
}
