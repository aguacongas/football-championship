using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Model
{
    public static class Queries
    {
        public const string LIST_COMPETITIONS = @"query ListCompetitions(
    $filter: ModelCompetitionFilterInput
    $limit: Int
    $nextToken: String
) {
    listCompetitions(filter: $filter, limit: $limit, nextToken: $nextToken) {
    items {
        id
        title
        from
        to
    }   
    nextToken
    }
}";
        public const string LIST_MATCH = @"query ListMatchs(
  $filter: ModelMatchFilterInput
  $limit: Int
  $nextToken: String
) {
  listMatchs(filter: $filter, limit: $limit, nextToken: $nextToken) {
    items {
      id 
      placeHolderAway
      placeHolderHome
      matchTeams {
        items {
          id
          isHome
          team {
            id
            name
          }
        }
      }
      scores
    }
    nextToken
  }
}";
    }
}
