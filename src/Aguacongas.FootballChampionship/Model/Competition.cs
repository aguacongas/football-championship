using Aguacongas.FootballChampionship.Services;
using System;
using System.Collections.Generic;

namespace Aguacongas.FootballChampionship.Model
{
    public class Competition
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }

        public IEnumerable<LocalizedName> LocalizedNames { get; set; }

        public AwsGraphQlList<Match> Matches { get; set; }

        public AwsGraphQlList<Result> Results { get; set; }

        public AwsGraphQlList<Bet> Bets { get; set; }
    }
}
