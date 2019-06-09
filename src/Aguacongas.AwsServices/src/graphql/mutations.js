// eslint-disable
// this is an auto generated file. This will be overwritten

export const createEnvironment = `mutation CreateEnvironment($input: CreateEnvironmentInput!) {
  createEnvironment(input: $input) {
    id
    results {
      nextToken
    }
  }
}
`;
export const updateEnvironment = `mutation UpdateEnvironment($input: UpdateEnvironmentInput!) {
  updateEnvironment(input: $input) {
    id
    results {
      nextToken
    }
  }
}
`;
export const deleteEnvironment = `mutation DeleteEnvironment($input: DeleteEnvironmentInput!) {
  deleteEnvironment(input: $input) {
    id
    results {
      nextToken
    }
  }
}
`;
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
export const createMatch = `mutation CreateMatch($input: CreateMatchInput!) {
  createMatch(input: $input) {
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
export const updateMatch = `mutation UpdateMatch($input: UpdateMatchInput!) {
  updateMatch(input: $input) {
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
export const deleteMatch = `mutation DeleteMatch($input: DeleteMatchInput!) {
  deleteMatch(input: $input) {
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
export const createTeam = `mutation CreateTeam($input: CreateTeamInput!) {
  createTeam(input: $input) {
    id
    name
    localizedNames {
      locale
      value
    }
    flagUrl
    matchTeams {
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
    flagUrl
    matchTeams {
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
    flagUrl
    matchTeams {
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
      flagUrl
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
export const updateMatchTeam = `mutation UpdateMatchTeam($input: UpdateMatchTeamInput!) {
  updateMatchTeam(input: $input) {
    id
    isHome
    team {
      id
      name
      flagUrl
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
export const deleteMatchTeam = `mutation DeleteMatchTeam($input: DeleteMatchTeamInput!) {
  deleteMatchTeam(input: $input) {
    id
    isHome
    team {
      id
      name
      flagUrl
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
export const createBet = `mutation CreateBet($input: CreateBetInput!) {
  createBet(input: $input) {
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
export const updateBet = `mutation UpdateBet($input: UpdateBetInput!) {
  updateBet(input: $input) {
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
export const deleteBet = `mutation DeleteBet($input: DeleteBetInput!) {
  deleteBet(input: $input) {
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
export const createResult = `mutation CreateResult($input: CreateResultInput!) {
  createResult(input: $input) {
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
export const updateResult = `mutation UpdateResult($input: UpdateResultInput!) {
  updateResult(input: $input) {
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
export const deleteResult = `mutation DeleteResult($input: DeleteResultInput!) {
  deleteResult(input: $input) {
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
export const createGlobalResult = `mutation CreateGlobalResult($input: CreateGlobalResultInput!) {
  createGlobalResult(input: $input) {
    id
    owner
    userName
    value
    environment {
      id
    }
  }
}
`;
export const updateGlobalResult = `mutation UpdateGlobalResult($input: UpdateGlobalResultInput!) {
  updateGlobalResult(input: $input) {
    id
    owner
    userName
    value
    environment {
      id
    }
  }
}
`;
export const deleteGlobalResult = `mutation DeleteGlobalResult($input: DeleteGlobalResultInput!) {
  deleteGlobalResult(input: $input) {
    id
    owner
    userName
    value
    environment {
      id
    }
  }
}
`;
