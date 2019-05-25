// eslint-disable
// this is an auto generated file. This will be overwritten

export const getCompetition = `query GetCompetition($id: ID!) {
  getCompetition(id: $id) {
    id
    title
    from
    to
    matches {
      items {
        id
        beginAt
        scores
      }
      nextToken
    }
  }
}
`;
export const listCompetitions = `query ListCompetitions(
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
      matches {
        nextToken
      }
    }
    nextToken
  }
}
`;
export const getMatch = `query GetMatch($id: ID!) {
  getMatch(id: $id) {
    id
    competition {
      id
      title
      from
      to
      matches {
        nextToken
      }
    }
    beginAt
    matchTeams {
      items {
        id
        isHome
      }
      nextToken
    }
    bets {
      items {
        id
        userName
        scores
      }
      nextToken
    }
    scores
  }
}
`;
export const listMatchs = `query ListMatchs(
  $filter: ModelMatchFilterInput
  $limit: Int
  $nextToken: String
) {
  listMatchs(filter: $filter, limit: $limit, nextToken: $nextToken) {
    items {
      id
      competition {
        id
        title
        from
        to
      }
      beginAt
      matchTeams {
        nextToken
      }
      bets {
        nextToken
      }
      scores
    }
    nextToken
  }
}
`;
export const getTeam = `query GetTeam($id: ID!) {
  getTeam(id: $id) {
    id
    name
    matchTeams {
      items {
        id
        isHome
      }
      nextToken
    }
  }
}
`;
export const listTeams = `query ListTeams(
  $filter: ModelTeamFilterInput
  $limit: Int
  $nextToken: String
) {
  listTeams(filter: $filter, limit: $limit, nextToken: $nextToken) {
    items {
      id
      name
      matchTeams {
        nextToken
      }
    }
    nextToken
  }
}
`;
export const getMatchTeam = `query GetMatchTeam($id: ID!) {
  getMatchTeam(id: $id) {
    id
    isHome
    team {
      id
      name
      matchTeams {
        nextToken
      }
    }
    match {
      id
      competition {
        id
        title
        from
        to
      }
      beginAt
      matchTeams {
        nextToken
      }
      bets {
        nextToken
      }
      scores
    }
  }
}
`;
export const listMatchTeams = `query ListMatchTeams(
  $filter: ModelMatchTeamFilterInput
  $limit: Int
  $nextToken: String
) {
  listMatchTeams(filter: $filter, limit: $limit, nextToken: $nextToken) {
    items {
      id
      isHome
      team {
        id
        name
      }
      match {
        id
        beginAt
        scores
      }
    }
    nextToken
  }
}
`;
export const getBet = `query GetBet($id: ID!) {
  getBet(id: $id) {
    id
    userName
    match {
      id
      competition {
        id
        title
        from
        to
      }
      beginAt
      matchTeams {
        nextToken
      }
      bets {
        nextToken
      }
      scores
    }
    scores
  }
}
`;
export const listBets = `query ListBets($filter: ModelBetFilterInput, $limit: Int, $nextToken: String) {
  listBets(filter: $filter, limit: $limit, nextToken: $nextToken) {
    items {
      id
      userName
      match {
        id
        beginAt
        scores
      }
      scores
    }
    nextToken
  }
}
`;
