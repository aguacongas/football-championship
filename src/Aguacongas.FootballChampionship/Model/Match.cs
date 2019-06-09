using Aguacongas.AwsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Model
{
    public class Match
    {
        public string Id { get; set; }

        public IEnumerable<LocalizedName> Group { get; set; }

        public int Number { get; set; }

        public DateTime BeginAt { get; set; }

        public DateTime BeginAtLocal { get; set; }

        public string PlaceHolderHome { get; set; }

        public string PlaceHolderAway { get; set; }

        public IEnumerable<LocalizedName> LocalizedNames { get; set; }

        public AwsGraphQlList<MatchTeam> MatchTeams { get; set; }

        public IEnumerable<Score> Scores { get; set; }

        public BetScore Bet { get; set; }

        public AwsGraphQlList<Bet> Bets { get; set; }

    }
}
