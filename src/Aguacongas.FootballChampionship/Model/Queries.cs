using System.Collections.Generic;

namespace Aguacongas.FootballChampionship.Model
{
    public static class Queries
    {
        public static IEnumerable<string> CULTURE_LIST = new List<string>
        {
            { "en-GB" },
            { "fr-FR" },
            { "de-De" }
        };

        public const string LIST_COMPETITIONS = @"query ListCompetitions(
    $filter: ModelCompetitionFilterInput
    $limit: Int
    $nextToken: String
) {
    listCompetitions(filter: $filter, limit: $limit, nextToken: $nextToken) {
      items {
        id
        title
        localizedNames {
          locale
          value
        }
        from
        to
      }   
      nextToken
    }
}";

        public const string GET_COMPETITION = @"query GetCompetition($id: ID!, $owner: String!) {
  getCompetition(id: $id) {
    id
    title
    localizedNames {
      locale
      value
    }
    from
    to
    matches(limit: 100, sortDirection: ASC) {
      items {
        id 
        beginAt
        group {
          locale
          value
        }
        number
        placeHolderAway
        placeHolderHome
        localizedNames {
          locale
          value
        }
        matchTeams {
          items {
            id
            isHome
            team {
              id
              name
              flagUrl
              localizedNames {
                locale
                value
              }
            }
          }
        }
        bets (filter: { owner: { eq: $owner} }) {
          items {
            id
            scores {
             isHome
             value
            }
          }
        }
        scores {
          isHome
          value
        }
      }
      nextToken
    }
    results(filter: { owner: { eq: $owner } }) {
      items {
         id
         userName
         value
      }
      nextToken
    }
  }
}";

        public const string LIST_BET = @"query ListBets($filter: ModelBetFilterInput, $limit: Int, $nextToken: String) {
  listBets(filter: $filter, limit: $limit, nextToken: $nextToken) {
    items {
      id
      userName
      match {
        id
      }
      scores {
        isHome
        value
      }
    }
    nextToken
  }
}";
        public const string LIST_RESULT = @"query GetCompetition($id: ID!) {
  getCompetition(id: $id) {
    id
    title
    localizedNames {
      locale
      value
    }
    from
    to
    results(sortDirection: DESC, limit: 1000) {
      items {
         userName
         value
      }
      nextToken
    }
  }
}";
    }
}
