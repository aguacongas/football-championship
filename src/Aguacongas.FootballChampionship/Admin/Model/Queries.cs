using System;
using System.Collections.Generic;
using System.Text;

namespace Aguacongas.FootballChampionship.Admin.Model
{
    class Queries
    {
        public const string GET_COMPETITION = @"query GetCompetition($id: ID!) {
  getCompetition(id: $id) {
    id
    title
    from
    to
  }
}";
        public const string GET_TEAM = @"query GetTeam($id: ID!) {
  getTeam(id: $id) {
    id
    name
  }
}";
    }
}
