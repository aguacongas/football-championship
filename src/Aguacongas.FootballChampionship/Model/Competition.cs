using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Model
{
    public class Competition
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }
    }
}
