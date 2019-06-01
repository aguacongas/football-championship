using Aguacongas.FootballChampionship.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Model
{
    public class Match
    {
        public string Id { get; set; }

        public DateTime BeginAt { get; set; }

        public string PlaceHolderHome { get; set; }

        public string PlaceHolderAway { get; set; }

        public AwsGraphQlList<MatchTeam> MatchTeams { get; set; }
    }
}
