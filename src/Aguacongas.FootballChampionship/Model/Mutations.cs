namespace Aguacongas.FootballChampionship.Model
{
    public static class Mutations
    {
        public const string CREATE_BET = @"mutation CreateBet($input: CreateBetInput!) {
  createBet(input: $input) {
    id
    userName
    match {
      id
    }
    competition {
      id
    }
    scores {
      isHome
      value
    }
  }
}";

        public const string UPDATE_BET = @"mutation UpdateBet($input: UpdateBetInput!) {
  updateBet(input: $input) {
    id
    userName
    match {
      id
    }
    competition {
      id
    }
    scores {
      isHome
      value
    }
  }
}";

        public const string CREATE_RESULT = @"mutation CreateResult($input: CreateResultInput!) {
  createResult(input: $input) {
    id
    owner
    userName
    value
    competition {
      id
    }
  }
}";
    }
}
