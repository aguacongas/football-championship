﻿using Aguacongas.AwsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Model
{
    public class Team
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string FlagUrl { get; set; }

        public IEnumerable<LocalizedName> LocalizedNames { get; set; }

        public AwsGraphQlList<MatchTeam> MatchTeams { get; set; }
    }
}
