// eslint-disable
// this is an auto generated file. This will be overwritten

export const onCreateCompetition = `subscription OnCreateCompetition {
  onCreateCompetition {
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
export const onUpdateCompetition = `subscription OnUpdateCompetition {
  onUpdateCompetition {
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
export const onDeleteCompetition = `subscription OnDeleteCompetition {
  onDeleteCompetition {
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
export const onCreateMatch = `subscription OnCreateMatch {
  onCreateMatch {
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
export const onUpdateMatch = `subscription OnUpdateMatch {
  onUpdateMatch {
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
export const onDeleteMatch = `subscription OnDeleteMatch {
  onDeleteMatch {
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
export const onCreateTeam = `subscription OnCreateTeam {
  onCreateTeam {
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
export const onUpdateTeam = `subscription OnUpdateTeam {
  onUpdateTeam {
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
export const onDeleteTeam = `subscription OnDeleteTeam {
  onDeleteTeam {
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
export const onCreateMatchTeam = `subscription OnCreateMatchTeam {
  onCreateMatchTeam {
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
export const onUpdateMatchTeam = `subscription OnUpdateMatchTeam {
  onUpdateMatchTeam {
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
export const onDeleteMatchTeam = `subscription OnDeleteMatchTeam {
  onDeleteMatchTeam {
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
export const onCreateBet = `subscription OnCreateBet {
  onCreateBet {
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
export const onUpdateBet = `subscription OnUpdateBet {
  onUpdateBet {
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
export const onDeleteBet = `subscription OnDeleteBet {
  onDeleteBet {
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
export const onCreateResult = `subscription OnCreateResult {
  onCreateResult {
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
export const onUpdateResult = `subscription OnUpdateResult {
  onUpdateResult {
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
export const onDeleteResult = `subscription OnDeleteResult {
  onDeleteResult {
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
