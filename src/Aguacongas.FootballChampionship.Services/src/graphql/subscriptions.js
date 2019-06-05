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
export const onCreateMatch = `subscription OnCreateMatch {
  onCreateMatch {
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
export const onUpdateMatch = `subscription OnUpdateMatch {
  onUpdateMatch {
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
export const onDeleteMatch = `subscription OnDeleteMatch {
  onDeleteMatch {
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
export const onCreateTeam = `subscription OnCreateTeam {
  onCreateTeam {
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
export const onUpdateTeam = `subscription OnUpdateTeam {
  onUpdateTeam {
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
export const onDeleteTeam = `subscription OnDeleteTeam {
  onDeleteTeam {
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
export const onCreateMatchTeam = `subscription OnCreateMatchTeam {
  onCreateMatchTeam {
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
export const onUpdateMatchTeam = `subscription OnUpdateMatchTeam {
  onUpdateMatchTeam {
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
export const onDeleteMatchTeam = `subscription OnDeleteMatchTeam {
  onDeleteMatchTeam {
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
export const onCreateBet = `subscription OnCreateBet {
  onCreateBet {
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
export const onUpdateBet = `subscription OnUpdateBet {
  onUpdateBet {
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
export const onDeleteBet = `subscription OnDeleteBet {
  onDeleteBet {
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
