using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Model
{
    public class Result
    {
        public string Id { get; set; }

        public string Owner { get; set; }

        public string UserName { get; set; }

        public int Value { get; set; }

        public Competition Competition { get; set; }
    }
}
