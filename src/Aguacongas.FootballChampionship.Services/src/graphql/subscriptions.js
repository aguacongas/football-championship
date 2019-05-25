// eslint-disable
// this is an auto generated file. This will be overwritten

export const onCreateCompetition = `subscription OnCreateCompetition {
  onCreateCompetition {
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
export const onUpdateCompetition = `subscription OnUpdateCompetition {
  onUpdateCompetition {
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
export const onDeleteCompetition = `subscription OnDeleteCompetition {
  onDeleteCompetition {
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
export const onCreateMatch = `subscription OnCreateMatch {
  onCreateMatch {
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
export const onUpdateMatch = `subscription OnUpdateMatch {
  onUpdateMatch {
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
export const onDeleteMatch = `subscription OnDeleteMatch {
  onDeleteMatch {
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
export const onCreateTeam = `subscription OnCreateTeam {
  onCreateTeam {
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
export const onUpdateTeam = `subscription OnUpdateTeam {
  onUpdateTeam {
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
export const onDeleteTeam = `subscription OnDeleteTeam {
  onDeleteTeam {
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
export const onCreateMatchTeam = `subscription OnCreateMatchTeam {
  onCreateMatchTeam {
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
export const onUpdateMatchTeam = `subscription OnUpdateMatchTeam {
  onUpdateMatchTeam {
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
export const onDeleteMatchTeam = `subscription OnDeleteMatchTeam {
  onDeleteMatchTeam {
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
export const onCreateBet = `subscription OnCreateBet {
  onCreateBet {
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
export const onUpdateBet = `subscription OnUpdateBet {
  onUpdateBet {
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
export const onDeleteBet = `subscription OnDeleteBet {
  onDeleteBet {
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
