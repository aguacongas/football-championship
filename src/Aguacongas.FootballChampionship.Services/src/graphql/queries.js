// eslint-disable
// this is an auto generated file. This will be overwritten

export const getCompetition = `query GetCompetition($id: ID!) {
  getCompetition(id: $id) {
    id
    title
    localizedNames {
      locale
      value
    }
    from
    to
    matches {
      nextToken
    }
    bets {
      nextToken
    }
    results {
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
    }
    group {
      locale
      value
    }
    number
    beginAt
    placeHolderHome
    placeHolderAway
    localizedNames {
      locale
      value
    }
    matchTeams {
      nextToken
    }
    bets {
      nextToken
    }
    scores {
      isHome
      value
    }
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
      number
      beginAt
      placeHolderHome
      placeHolderAway
    }
    nextToken
  }
}
`;
export const getTeam = `query GetTeam($id: ID!) {
  getTeam(id: $id) {
    id
    name
    localizedNames {
      locale
      value
    }
    matchTeams {
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
    }
    match {
      id
      number
      beginAt
      placeHolderHome
      placeHolderAway
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
    }
    nextToken
  }
}
`;
export const getBet = `query GetBet($id: ID!) {
  getBet(id: $id) {
    id
    owner
    userName
    match {
      id
      number
      beginAt
      placeHolderHome
      placeHolderAway
    }
    competition {
      id
      title
      from
      to
    }
    scores {
      isHome
      value
    }
  }
}
`;
export const listBets = `query ListBets($filter: ModelBetFilterInput, $limit: Int, $nextToken: String) {
  listBets(filter: $filter, limit: $limit, nextToken: $nextToken) {
    items {
      id
      owner
      userName
    }
    nextToken
  }
}
`;
export const getResult = `query GetResult($id: ID!) {
  getResult(id: $id) {
    id
    owner
    userName
    value
    competition {
      id
      title
      from
      to
    }
  }
}
`;
export const listResults = `query ListResults(
  $filter: ModelResultFilterInput
  $limit: Int
  $nextToken: String
) {
  listResults(filter: $filter, limit: $limit, nextToken: $nextToken) {
    items {
      id
      owner
      userName
      value
    }
    nextToken
  }
}
`;
