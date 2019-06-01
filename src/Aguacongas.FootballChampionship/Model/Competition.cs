using Aguacongas.FootballChampionship.Services;
using System;

namespace Aguacongas.FootballChampionship.Model
{
    public class Competition
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }

        public AwsGraphQlList<Match> Matches { get; set; }
    }
}
