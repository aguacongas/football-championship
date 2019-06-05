// eslint-disable
// this is an auto generated file. This will be overwritten

export const createCompetition = `mutation CreateCompetition($input: CreateCompetitionInput!) {
  createCompetition(input: $input) {
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
        scores
      }
      nextToken
    }
  }
}
`;
export const updateCompetition = `mutation UpdateCompetition($input: UpdateCompetitionInput!) {
  updateCompetition(input: $input) {
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
        scores
      }
      nextToken
    }
  }
}
`;
export const deleteCompetition = `mutation DeleteCompetition($input: DeleteCompetitionInput!) {
  deleteCompetition(input: $input) {
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
        scores
      }
      nextToken
    }
  }
}
`;
export const createMatch = `mutation CreateMatch($input: CreateMatchInput!) {
  createMatch(input: $input) {
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
        userName
        scores
      }
      nextToken
    }
    scores
  }
}
`;
export const updateMatch = `mutation UpdateMatch($input: UpdateMatchInput!) {
  updateMatch(input: $input) {
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
        userName
        scores
      }
      nextToken
    }
    scores
  }
}
`;
export const deleteMatch = `mutation DeleteMatch($input: DeleteMatchInput!) {
  deleteMatch(input: $input) {
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
        userName
        scores
      }
      nextToken
    }
    scores
  }
}
`;
export const createTeam = `mutation CreateTeam($input: CreateTeamInput!) {
  createTeam(input: $input) {
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
export const updateTeam = `mutation UpdateTeam($input: UpdateTeamInput!) {
  updateTeam(input: $input) {
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
export const deleteTeam = `mutation DeleteTeam($input: DeleteTeamInput!) {
  deleteTeam(input: $input) {
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
export const createMatchTeam = `mutation CreateMatchTeam($input: CreateMatchTeamInput!) {
  createMatchTeam(input: $input) {
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
      scores
    }
  }
}
`;
export const updateMatchTeam = `mutation UpdateMatchTeam($input: UpdateMatchTeamInput!) {
  updateMatchTeam(input: $input) {
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
      scores
    }
  }
}
`;
export const deleteMatchTeam = `mutation DeleteMatchTeam($input: DeleteMatchTeamInput!) {
  deleteMatchTeam(input: $input) {
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
      scores
    }
  }
}
`;
export const createBet = `mutation CreateBet($input: CreateBetInput!) {
  createBet(input: $input) {
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
      scores
    }
    scores
  }
}
`;
export const updateBet = `mutation UpdateBet($input: UpdateBetInput!) {
  updateBet(input: $input) {
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
      scores
    }
    scores
  }
}
`;
export const deleteBet = `mutation DeleteBet($input: DeleteBetInput!) {
  deleteBet(input: $input) {
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
      scores
    }
    scores
  }
}
`;
