using System.Collections.Generic;

namespace Aguacongas.FootballChampionship.Model
{
    public class MatchTeam
    {
        public string Id { get; set; }

        public bool IsHome { get; set; }

        public Team Team { get; set; }

        public Match Match { get; set; }
    }
}
