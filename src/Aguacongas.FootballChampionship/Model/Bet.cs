using System.Collections.Generic;

namespace Aguacongas.FootballChampionship.Model
{
    public class Bet
    {
        public string Id { get; set; }

        public string Owner { get; set; }

        public IEnumerable<Score> Scores { get; set; }

        public Match Match { get; set; }

        public Competition Competition { get; set; }
        public string UserName { get; set; }
    }
}
