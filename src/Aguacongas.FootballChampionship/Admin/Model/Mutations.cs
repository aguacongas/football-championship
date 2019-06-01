namespace Aguacongas.FootballChampionship.Admin.Model
{
    class Mutations
    {
        public const string CREATE_COMPETITION = @"mutation CreateCompetition($input: CreateCompetitionInput!) {
  createCompetition(input: $input) {
    id
    title
    from
    to
  }
}
";
        public const string UPDATE_COMPETITION = @"mutation UpdateCompetition($input: UpdateCompetitionInput!) {
  updateCompetition(input: $input) {
    id
    title
    from
    to
  }
}
";

        public const string CREATE_MATCH = @"mutation CreateMatch($input: CreateMatchInput!) {
  createMatch(input: $input) {
    id
    beginAt
    placeHolderAway
    placeHolderHome
    matchTeams {
      items {
        id
        isHome
        team {
          id
        }
      }
    }
  }
}";
        public const string UPDATE_MATCH = @"mutation UpdateMatch($input: UpdateMatchInput!) {
  updateMatch(input: $input) {
    id
    beginAt
    placeHolderAway
    placeHolderHome
    matchTeams {
      items {
        id
        isHome
        team {
          id
        }
      }
    }
  }
}";
        public const string CREATE_TEAM = @"mutation CreateTeam($input: CreateTeamInput!) {
  createTeam(input: $input) {
    id
    name
  }
}";

        public const string UPDATE_TEAM = @"mutation UpdateTeam($input: UpdateTeamInput!) {
  updateTeam(input: $input) {
    id
    name
  }
}";
        public const string CREATE_MATCH_TEAM = @"mutation CreateMatchTeam($input: CreateMatchTeamInput!) {
  createMatchTeam(input: $input) {
    id
    isHome
  }
}";
        public const string UPDATE_MATCH_TEAM = @"mutation UpdateMatchTeam($input: UpdateMatchTeamInput!) {
  updateMatchTeam(input: $input) {
    id
    isHome
  }
}";
    }
}
