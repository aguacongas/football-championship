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
      localizedNames {
        locale
        value
      }
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
      localizedNames {
        locale
        value
      }
      from
      to
      matches {
        nextToken
      }
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
      items {
        id
        isHome
      }
      nextToken
    }
    bets {
      items {
        id
        owner
        userName
        competitionId
      }
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
      localizedNames {
        locale
        value
      }
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
      localizedNames {
        locale
        value
      }
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
        number
        beginAt
        placeHolderHome
        placeHolderAway
      }
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
    competitionId
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
      match {
        id
        number
        beginAt
        placeHolderHome
        placeHolderAway
      }
      competitionId
      scores {
        isHome
        value
      }
    }
    nextToken
  }
}
`;
